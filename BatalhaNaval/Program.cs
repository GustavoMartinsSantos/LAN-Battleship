using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace BatalhaNaval {
    class Program {
        static char[,] mapa = new char[10, 10] {{'0','1','2','3','4','5','6','7','8','9'},
                                                {'1','~','~','~','~','~','~','~','~','~'},
                                                {'2','~','~','~','~','~','~','~','~','~'},
                                                {'3','~','~','~','~','~','~','~','~','~'},
                                                {'4','~','~','~','~','~','~','~','~','~'},
                                                {'5','~','~','~','~','~','~','~','~','~'},
                                                {'6','~','~','~','~','~','~','~','~','~'},
                                                {'7','~','~','~','~','~','~','~','~','~'},
                                                {'8','~','~','~','~','~','~','~','~','~'},
                                                {'9','~','~','~','~','~','~','~','~','~'}};

        static char[,] jogadas = mapa;

        static void Main(string[] args) {
            Console.Write("Deseja ser o host [S/N]? ");
            string host = Console.ReadLine();

            try {
                Console.Write("Digite o número da porta/protocolo: ");
                int port_num = int.Parse(Console.ReadLine());

                if (host.ToUpper() == "SIM" || host.ToUpper() == "S")
                    ServerSide(port_num);
                else {
                    Console.Write("Digite o IP do host: ");
                    string ip_host = Console.ReadLine();

                    ClientSide(ip_host, port_num);
                }
            } catch (Exception e) {
                Console.WriteLine("Falha na conexão...");
            }

            Console.Write("Deseja continuar [S/N]? ");
            string mensagem = Console.ReadLine();
            mensagem.ToLower();
            if (mensagem == "sim" || mensagem == "s")
                Main(null);
        }

        static void ServerSide(int port_num) {
            // "System.Net.IPAddress.Any" perrmite fazer uma conexão local (LAN) por qualquer IP
            TcpListener server = new TcpListener(IPAddress.Any, port_num);
            server.Start();

            Console.Write("Digite seu nome: ");
            string nome_user = Console.ReadLine();

            InserirNavio(1);

            Console.WriteLine("Esperando uma conexão na porta " + port_num + "...");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Conexão feita com sucesso.");
            NetworkStream stream = client.GetStream();

            EnviandoCampo(stream, mapa);

            char[,] campo_copia = new char[10, 10];
            LendoCampo(stream, campo_copia);

            int acertos = 0;
            int qtd_acertos = 2;
            while (acertos < qtd_acertos) {
                // enviando resposta
                acertos = VerificarCampo(stream, mapa, campo_copia, jogadas, acertos, qtd_acertos, nome_user);
                
                // receber resposta de suposto vencedor
                byte[] buffer = new byte[100];
                string resposta;
                stream.Read(buffer, 0, buffer.Length);
                int tamanho_resposta = 0;

                foreach(byte b in buffer) {
                    if (b != '\0')
                        tamanho_resposta++;
                    else
                        break;
                }

                resposta = Encoding.ASCII.GetString(buffer, 0, tamanho_resposta);
                Console.WriteLine(resposta);

                if(resposta != "Sua vez...")
                    break;
            }
        }

        static void ClientSide(string ip_host, int port_num) {
            TcpClient client = new TcpClient(ip_host, port_num);
            NetworkStream stream = client.GetStream();

            Console.Write("Digite seu nome: ");
            string nome_user = Console.ReadLine();

            InserirNavio(1);

            char[,] campo_copia = new char[10, 10];
            LendoCampo(stream, campo_copia);
            Console.Clear();

            EnviandoCampo(stream, mapa);

            int acertos = 0;
            int qtd_acertos = 2;
            while (acertos < qtd_acertos) {
                // receber resposta de suposto vencedor
                byte[] buffer = new byte[100];
                string resposta;
                stream.Read(buffer, 0, buffer.Length);
                int tamanho_resposta = 0;

                foreach (byte b in buffer) {
                    if (b != '\0')
                        tamanho_resposta++;
                    else
                        break;
                }

                resposta = Encoding.ASCII.GetString(buffer, 0, tamanho_resposta);
                Console.WriteLine(resposta);

                if (resposta != "Sua vez...")
                    break;

                // enviando resposta
                acertos = VerificarCampo(stream, mapa, campo_copia, jogadas, acertos, qtd_acertos, nome_user);
            }
        }

        static int VerificarCampo(NetworkStream stream, char [,] mapa_jogador, char[,] campo_adversario, char[,] jogadas, int acertos, int qtd, string nome_vencedor) {
            string mensagem = "Sua vez...";
            Console.WriteLine(mensagem);

            acertando:
                Console.Clear();
                Console.Write("        Campo Original        ");
                Console.WriteLine("     Campo de Verificação     ");
                for (int y = 0; y < 10; y++) {
                    for (int x = 0; x < 10; x++) {
                        Console.Write("[" + mapa_jogador[y, x] + "]");
                        if (x == 9) {
                            Console.Write("||");
                            for (int w = 0; w < 10; w++)
                                Console.Write("[" + jogadas[y, w] + "]");
                        }
                    }

                    Console.WriteLine();
                }

                Console.Write("Digite a posição vertical da bomba: ");
                int vertical = int.Parse(Console.ReadLine());

                Console.Write("Digite a posição horizontal da bomba: ");
                int horizontal = int.Parse(Console.ReadLine());

                if(jogadas[vertical, horizontal] == 'X')
                    goto acertando;
                else if (campo_adversario[vertical, horizontal] == 'X') {
                    jogadas[vertical, horizontal] = 'X';
                    acertos++;
                    if(acertos < qtd)
                        goto acertando;
                    else {
                        Console.Clear();
                        Console.WriteLine("Parabéns você venceu o jogo.");

                        mensagem = "O jogador " + nome_vencedor + " ganhou.";
                    }
                }

                byte[] send = new byte[100];
                send = Encoding.ASCII.GetBytes(mensagem);
                stream.Write(send, 0, mensagem.Length);

            return acertos;
        }
        
        static void InserirNavio(int qtd) {
            continuar:
                mapa = new char[10, 10] {{'0','1','2','3','4','5','6','7','8','9'},
                                         {'1','~','~','~','~','~','~','~','~','~'},
                                         {'2','~','~','~','~','~','~','~','~','~'},
                                         {'3','~','~','~','~','~','~','~','~','~'},
                                         {'4','~','~','~','~','~','~','~','~','~'},
                                         {'5','~','~','~','~','~','~','~','~','~'},
                                         {'6','~','~','~','~','~','~','~','~','~'},
                                         {'7','~','~','~','~','~','~','~','~','~'},
                                         {'8','~','~','~','~','~','~','~','~','~'},
                                         {'9','~','~','~','~','~','~','~','~','~'}};
                Console.Clear();

                int[] escolha_usuario = new int[10];

                // qtd indica a quantidade de vezes ocorrerá a inserção de um novo navio
                for (int z = 0; z < qtd; z++) {
                    // impressão do campo inicial
                    for (int y = 0; y < 10; y++) {
                        for (int x = 0; x < 10; x++) 
                            Console.Write("[" + mapa[y, x] + "]");
                        
                        Console.WriteLine();
                    }

                    string[] navios = { "XX", "XX", "XXX", "X", "XXXX", "X", "X", "X", "XX", "XXX" };

                    // Eliminação dos navios já usados
                    for(int x = 0; x < 10; x++) {
                        bool sair = false;
                        for(int c = 0; c < 10; c++) {
                            if (escolha_usuario[0] != 0 && escolha_usuario[c] == x+1) {
                                sair = true;
                                break;
                            }
                        }

                        if (sair == true)
                            continue;
                        if (x == 9)
                            Console.WriteLine("{0} - {1}.", x + 1, navios[x]);
                        else
                            Console.Write("{0} - {1}, ", x + 1, navios[x]);
                    }

                    Console.Write("Digite o número do navio escolhido: ");
                    escolha:
                        int escolha = int.Parse(Console.ReadLine());

                        // verificação de se o navio escolhido já foi escolhido
                        for (int x = 0; x < 10; x++) {
                            if (escolha == escolha_usuario[x]) {
                                Console.WriteLine("Navio já escolhido. Digite outro número: ");
                                goto escolha;
                            } 
                            
                            if (escolha_usuario[x] == 0) {
                                escolha_usuario[x] = escolha;
                                break;
                            }
                        }

                    Console.Write("Digite V para colocar o navio verticalmente e H para colocá-lo horizontalmente: ");
                    string posicao = Console.ReadLine();

                    Console.Write("Digite a posição vertical inicial que o navio estará: ");
                    int vertical = int.Parse(Console.ReadLine());

                    Console.Write("Digite a posição horizontal inicial que o navio estará: ");
                    int horizontal = int.Parse(Console.ReadLine());

                    int cont = 0;

                if (vertical < 0 || vertical > 9 || horizontal < 0 || horizontal > 9)
                    goto continuar;
                else if (posicao.ToUpper() == "H" || posicao.ToUpper() == "HORIZONTAL") {
                    for (int x = 1; x <= navios[escolha - 1].Length; x++) {
                        if (mapa[vertical, horizontal + cont] != 'X')
                            mapa[vertical, horizontal + cont] = 'X';
                        else {
                            Console.Clear();
                            goto continuar;
                        }

                        cont++;
                    }
                } else if (posicao.ToUpper() == "V" || posicao.ToUpper() == "VERTICAL") {
                    for (int x = 1; x <= navios[escolha - 1].Length; x++) {
                        if (mapa[vertical + cont, horizontal] != 'X')
                            mapa[vertical + cont, horizontal] = 'X';
                        else {
                            Console.Clear();
                            goto continuar;
                        }

                        cont++;
                    }
                } else
                    goto continuar;

                    Console.Clear();
                }
        }

        static void EnviandoCampo(NetworkStream stream, char[,] campo) {
            string message = "";
            for (int y = 0; y < 10; y++) {
                for (int x = 0; x < 10; x++) {
                    if (campo[y, x] != 'X')
                        message += '~';
                    else
                        message += campo[y, x];
                }

                message += '.';
            }

            // enviando o campo
            byte[] send = new byte[110];
            send = Encoding.ASCII.GetBytes(message);
            stream.Write(send, 0, send.Length);
        }

        static void LendoCampo(NetworkStream stream, char[,] campo_copia) {
            byte[] buffer = new byte[110];
            Console.WriteLine("Aguarde até o jogador adversário criar o seu campo...");
            stream.Read(buffer, 0, buffer.Length);

            int linha = 0;
            int coluna = 0;
            for (int x = 0; x < 110; x++) {
                if (buffer[x] != 46) {
                    campo_copia[linha, coluna] += Convert.ToChar(buffer[x]);

                    if (coluna != 9)
                        coluna++;
                    else {
                        coluna = 0;
                        linha++;
                    }
                }
            }
        }
    }
}