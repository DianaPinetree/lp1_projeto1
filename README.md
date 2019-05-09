<!--\mainpage-->
# Relatório do trabalho
## **1º Projeto de Linguagens de Programação 1 - 18Ghosts**

**Trabalho realizado por:**

- [Afonso Rosa, a21802169](https://github.com/AfonsoGR)
- [Pedro Inácio, a21802050](https://github.com/PmaiWoW)
- [Rodrigo Pinheiro, a21802488](https://github.com/RodrigoPrinheiro)

### [Repositório Git Utilizado](https://github.com/RodrigoPrinheiro/lp1_projeto1)

#### Distribuição e Realização do Projeto:

- Afonso Rosa:
    
    - Construção da classe `Text` e estruturação da mesma, adição das restrições no método `PickColor` da classe `Player` que impedem o jogadores de ter mais de 3 fantasmas de uma cor e que os proíbem de colocar fantasmas de uma cor após já não haver mais para meter. Aprofundamento substancial do ficheiro `README.md`, sendo o responsável pelo [Markdown](https://guides.github.com/features/mastering-markdown/) e pela estruturação e organização do mesmo, e diversas alterações e realização do `Fluxograma`.
- Pedro Inácio:

    - Construção dos métodos `MoveGhost`, `MirrorInterectionCheck` e `MirrorChoice` da class `Player` que tratam do movimento dos fantasmas no tabuleiro de jogo e realização do `Diagrama UML`.
- Rodrigo Pinheiro:

    - Construção e estruturação das classes `BoardClass`, `Cell`, `CellColor`, `CellType`, `Game`, `Player`, `Portal`, `Position`, `Program`, `Renderer` e `WinCheck` e documentação adequada das mesmas. Realização das classes `BoardClass`, `Cell`, `CellColor`, `CellType`, `Game`, `Portal`, `Position`, `Program`, `Renderer` e `WinCheck` na sua **totalidade** e realização substancial da classe `Player`. Correção da ortografia na classe `Text`. Realização da versão inicial do `README.md` e várias alterações, verificação do `Fluxograma`, realização do `Doxygen` e incorporação da imagem do `Fluxograma` em `git lfs`.

#### Arquitetura do Programa:

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

#### [Diagrama UML](https://drive.google.com/file/d/1iydRDRKKwkLcJhz3KOTjGKMDG71ldKUa/view?usp=sharing)
![DiagramaUML](diagramaUml.png)

#### [Fluxograma](https://drive.google.com/file/d/1LfA4-4dr6Sf2HyhDFZUAkrbw2Wnu33jO/view?usp=sharing)
![Fluxograma](fluxograma.png)

### Conclusões e Matéria aprendida:


### Referências:
1. Classe _Portal_ foi usada a resposta a [este](https://stackoverflow.com/questions/30258832/select-next-child-in-array-using-c-sharp) _post_ do stackOverflow, o uso da _keyword_ throw foi importante para _debugging_ do código correspondente;
2. Solução do exercício 30 das bases de cs deste [repositório](https://github.com/VideojogosLusofona/lp1_exercicios) para os movimentos dos fantasmas;
3. PDFs das aulas de Linguagens de Programação 1, em particular o da aula 08, que serviu para verificar a matéria relacionada a propriedades, diagramas UML e fluxogramas.
4. Utilização da biblioteca online [.NET API](https://docs.microsoft.com/en-us/dotnet/api/) da Microsoft.
5. Troca de ideias com o colega [Tomás Franco, a21803301](https://github.com/ThomasFranque), em particular de como executar o movimento e de como tratar dos portais, ainda tendo ajudado num problema de incrementação do método `PickColor` na classe `Player` e sugestão de mudar os métodos da classe `Text` para `static`.
6. Troca de ideias com o colega [João Moreira, a21801608](https://github.com/Slatius), tendo ajudado num problema do movimento, presente no método `MoveGhost` e ajudou ainda a meter o movimento entre os _mirrors_ a funcionar, isto nos métodos `MirroInteractionCheck` e `MirroChoice`, todos da classe `Player`.

