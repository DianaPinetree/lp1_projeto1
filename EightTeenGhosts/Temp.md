## Temporary help, delete once is done
# **1º Projeto de Linguagens de Programação I - 18Ghosts** cheat sheet

**Trabalho realizado por:**
- Afonso Rosa, a21802169 
- Pedro Inácio, a21802050
- Rodrigo Pinheiro, a21802488

#### [Repositório Git utilizado](https://github.com/RodrigoPrinheiro/lp1_projeto1)

### **Realização do Projecto:**

- Afonso Rosa:
    
    - PLACEHOLDER
- Pedro Inácio:

    - PLACEHOLDER
- Rodrigo Pinheiro:

    - PLACEHOLDER 



### Composição do programa

#### [Diagrama UML](https://drive.google.com/file/d/1dL46pckbe5K2Tr9PMW4zzPoOEJy25Hhi/view?usp=sharing)

#### [Fluxograma](PLACEHOLDER)

- Enumeração para os estados possíveis de 1 célula.

- Class de posição com propriedades Coluna e Linha para guardar 
	a posição de cada célula

- Class Board para guardar a parte central do jogo, tabuleiro, em que contem
	a matriz do tabuleiro de valores ESTADO (enumeracao), 
	funcoes de pedir estado, mudar estados de células e uma forma de keep track
	do turno em que se está.

- Class Player que controla os inputs feitos pelos jogadores 
	(maybe arranjar forma de o fazer com rato?) 
	ex: public Position GetPosition(Board currentState)

- Class WinChecker, isto é uma class unicamente para verificar o estado do jogo
	através do tabuleiro, funcao para ver se alguem ganhou, e uma para ver se
	há algum empate.
	ex: public StateCheck(Board currentState)
	public bool DrawCheck(Board currentState)

- Class Renderer para desenhar o estado do jogo, tabuleiro, e quem ganha
	a partir do tabuleiro.


                        case (CellState.Mirror):
                            {
                                
                                break;
                            }
                        case (CellState.Portal):
                            {
                                Console.Write($"|  ");
                                switch (i)
                                {
                                    case (0):
                                        {
                                            Console.ForegroundColor = 
                                                ConsoleColor.Red;
                                            break;
                                        }
                                    case (2):
                                        {
                                            Console.ForegroundColor =
                                                ConsoleColor.Yellow;
                                            break;
                                        }
                                    case (4):
                                        {
                                            Console.ForegroundColor =
                                                ConsoleColor.Blue;
                                            break;
                                        }
                                }
                                Console.Write($"P");
                                Console.ResetColor();
                                if(i == 2)
                                    Console.Write($"  |");
                                else
                                    Console.Write($"  ");
                                break;
                            }
                        default:
                            {
                                if (j == 4)
                                {
                                    Console.Write($"|   ");
                                    Console.Write($"  |");
                                }
                                else
                                {
                                    Console.Write($"|   ");
                                    Console.Write($"  ");
                                }
                                break;
                            }