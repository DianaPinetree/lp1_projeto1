\mainpage
## Relatório do trabalho
# **1º Projeto de Linguagens de Programação I - 18Ghosts**

**Trabalho realizado por:**
- [Afonso Rosa, a21802169](https://github.com/AfonsoGR)
- [Pedro Inácio, a21802050](https://github.com/PmaiWoW)
- [Rodrigo Pinheiro, a21802488](https://github.com/RodrigoPrinheiro)

#### [Repositório Git Utilizado](https://github.com/RodrigoPrinheiro/lp1_projeto1)

### Realização do Projeto:

- Afonso Rosa:
    
    - PLACEHOLDER
- Pedro Inácio:

    - PLACEHOLDER
- Rodrigo Pinheiro:

    - PLACEHOLDER 



### Arquitetura do Programa:

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

### Conclusões:


### Referências: