namespace Chess_console.Tabuleiro
{
    internal class ClassTabuleiro
    {
        public int Linhas {  get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public ClassTabuleiro() { }

        public ClassTabuleiro (int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int colunas)
        {
            return pecas[linha, colunas];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool existePeca (Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca (Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new Exception("Já existe uma peça nesta posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.ObjPosicao = pos;

        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.ObjPosicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false; 
            }

            return true;
        }

        public void validarPosicao (Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

    }
}
