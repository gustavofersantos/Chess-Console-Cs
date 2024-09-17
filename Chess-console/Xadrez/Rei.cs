using Chess_console.Tabuleiro;

namespace Chess_console.Xadrez
{
    internal class Rei : Peca
    {
        public Rei(ClassTabuleiro tab, Cor cor) : base(tab, cor) { }

        private PartidaXadrez Partida;

        public Rei (ClassTabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {

        Partida = partida;
        }

        private bool testeTorreRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //norte
            pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //nordeste
            pos.definirValores(ObjPosicao.Linha - 1, ObjPosicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //leste
            pos.definirValores(ObjPosicao.Linha, ObjPosicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudeste
            pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sul
            pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudoeste
            pos.definirValores(ObjPosicao.Linha + 1, ObjPosicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //oeste
            pos.definirValores(ObjPosicao.Linha, ObjPosicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //noroeste
            pos.definirValores(ObjPosicao.Linha - 1, ObjPosicao.Coluna -1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#jogada especial roque

            if(QteMovimentos == 0 && !Partida.Xeque)
            {
                //roque pequeno ala do rei
                Posicao posT1 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna + 3);
                if (testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna + 1);
                    Posicao p2 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[ObjPosicao.Linha, ObjPosicao.Coluna + 2] = true;
                    }
                }
            }

            if (QteMovimentos == 0 && !Partida.Xeque)
            {
                //roque grande ala da dama

                Posicao posT2 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 4);
                if (testeTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 1);
                    Posicao p2 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 2);
                    Posicao p3 = new Posicao(ObjPosicao.Linha, ObjPosicao.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[ObjPosicao.Linha, ObjPosicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }


        public override string ToString()
        {
            return "R ";
        }
    }
}
