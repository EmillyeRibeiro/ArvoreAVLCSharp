using System;

namespace ArvoreAVL
{
    public class Arvore
    {
        private No? Raiz;

        public void Inserir(int valor)
        {
            Raiz = Inserir(Raiz, valor);
        }

        private No Inserir(No? no, int valor)
        {
            if (no == null)
                return new No(valor);

            if (valor < no.Valor)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Inserir(no.Direita, valor);
            else
                return no;

            AtualizarAltura(no);
            return Balancear(no);
        }

        public void Remover(int valor)
        {
            Raiz = Remover(Raiz, valor);
        }

        private No? Remover(No? no, int valor)
        {
            if (no == null)
                return null;

            if (valor < no.Valor)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Remover(no.Direita, valor);
            else
            {
                if (no.Esquerda == null || no.Direita == null)
                    return no.Esquerda ?? no.Direita;

                No sucessor = EncontrarMenor(no.Direita);
                no.Valor = sucessor.Valor;
                no.Direita = Remover(no.Direita, sucessor.Valor);
            }

            AtualizarAltura(no);
            return Balancear(no);
        }

        private No EncontrarMenor(No? no)
        {
            while (no!.Esquerda != null)
                no = no.Esquerda;
            return no;
        }

        public bool Buscar(int valor)
        {
            return Buscar(Raiz, valor) != null;
        }

        private No? Buscar(No? no, int valor)
        {
            if (no == null)
                return null;

            if (valor == no.Valor)
                return no;
            else if (valor < no.Valor)
                return Buscar(no.Esquerda, valor);
            else
                return Buscar(no.Direita, valor);
        }

        public bool Existe(int valor)
        {
            return Buscar(valor);
        }

        public void ImprimirInOrder()
        {
            ImprimirInOrder(Raiz);
            Console.WriteLine();
        }

        private void ImprimirInOrder(No? no)
        {
            if (no != null)
            {
                ImprimirInOrder(no.Esquerda);
                Console.Write($"{no.Valor} ");
                ImprimirInOrder(no.Direita);
            }
        }

        public void ImprimirPreOrdem()
        {
            ImprimirPreOrdem(Raiz);
            Console.WriteLine();
        }

        private void ImprimirPreOrdem(No? no)
        {
            if (no == null) return;

            Console.Write(no.Valor + " ");
            ImprimirPreOrdem(no.Esquerda);
            ImprimirPreOrdem(no.Direita);
        }

        public void ImprimirPosOrdem()
        {
            ImprimirPosOrdem(Raiz);
            Console.WriteLine();
        }

        private void ImprimirPosOrdem(No? no)
        {
            if (no == null) return;

            ImprimirPosOrdem(no.Esquerda);
            ImprimirPosOrdem(no.Direita);
            Console.Write(no.Valor + " ");
        }

        public void VerificarBalanceamento()
        {
            VerificarBalanceamento(Raiz);
        }

        private void VerificarBalanceamento(No? no)
        {
            if (no != null)
            {
                VerificarBalanceamento(no.Esquerda);
                int fb = FatorBalanceamento(no);
                Console.WriteLine($"Nó {no.Valor} - FB = {fb}");
                VerificarBalanceamento(no.Direita);
            }
        }

        public void ImprimirArvoreVisual()
        {
            ImprimirArvoreVisual(Raiz, " ", true);
        }

        private void ImprimirArvoreVisual(No? no, string prefixo, bool ehFilhoDireito)
        {
            if (no != null)
            {
                Console.WriteLine(prefixo + (ehFilhoDireito ? "└── " : "├── ") + no.Valor);
                ImprimirArvoreVisual(no.Direita, prefixo + (ehFilhoDireito ? "    " : "│   "), false);
                ImprimirArvoreVisual(no.Esquerda, prefixo + (ehFilhoDireito ? "    " : "│   "), true);
            }
        }

        private int Altura(No? no) => no?.Altura ?? 0;

        private void AtualizarAltura(No no)
        {
            no.Altura = 1 + Math.Max(Altura(no.Esquerda), Altura(no.Direita));
        }

        private int FatorBalanceamento(No no)
        {
            return Altura(no.Esquerda) - Altura(no.Direita);
        }

        private No Balancear(No no)
        {
            int fb = FatorBalanceamento(no);

            if (fb > 1)
            {
                if (FatorBalanceamento(no.Esquerda!) < 0)
                    no.Esquerda = RotacionarEsquerda(no.Esquerda!);
                return RotacionarDireita(no);
            }
            if (fb < -1)
            {
                if (FatorBalanceamento(no.Direita!) > 0)
                    no.Direita = RotacionarDireita(no.Direita!);
                return RotacionarEsquerda(no);
            }

            return no;
        }

        private No RotacionarDireita(No y)
        {
            No x = y.Esquerda!;
            No T2 = x.Direita!;

            x.Direita = y;
            y.Esquerda = T2;

            AtualizarAltura(y);
            AtualizarAltura(x);

            return x;
        }

        private No RotacionarEsquerda(No x)
        {
            No y = x.Direita!;
            No T2 = y.Esquerda!;

            y.Esquerda = x;
            x.Direita = T2;

            AtualizarAltura(x);
            AtualizarAltura(y);

            return y;
        }
    }
}
