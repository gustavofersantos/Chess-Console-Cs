namespace Chess_console.Tabuleiro
{
    internal abstract class Peca
    {
        public Posicao ObjPosicao {  get; set; }
        public Cor Cor {  get; set; }
        public int QteMovimentos { get; set; }
        public ClassTabuleiro Tab {  get; protected set; }

        public Peca() { }
        public Peca(ClassTabuleiro tabuleiro, Cor cor)
        {
            ObjPosicao = null;
            Tab = tabuleiro;
            Cor = cor;
            QteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < Tab.Linhas;  i++)
            {
                for (int j = 0; j < Tab.Linhas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
