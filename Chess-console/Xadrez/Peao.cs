using Chess_console.Tabuleiro;

namespace Chess_console.Xadrez
{
    internal class Peao : Peca
    {

        private PartidaXadrez Partida;

        public Peao(ClassTabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P ";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                // Movimentos normais para o peão branco
                pos.definirValores(ObjPosicao.Linha - 1, ObjPosicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha - 2, ObjPosicao.Coluna);
                Posicao p2 = new Posicao(ObjPosicao.Linha - 1, ObjPosicao.Coluna);
                if (Tab.posicaoValida(p2) && livre(p2) && Tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha - 1, ObjPosicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha - 1, ObjPosicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant para peões brancos
                if (ObjPosicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 1);
                    if (Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                // Movimentos normais para o peão preto
                pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha + 2, ObjPosicao.Coluna);
                Posicao p2 = new Posicao(ObjPosicao.Linha + 1, ObjPosicao.Coluna);
                if (Tab.posicaoValida(p2) && livre(p2) && Tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant para peões pretos
                if (ObjPosicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 1);
                    if (Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}