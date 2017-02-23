using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacaoAutomatos.Classes;

namespace TesteProva
{
    [TestClass]
    public class Exercicios
    {

        /// <summary>
        /// O exercício 1 requer a implementação do operador & que deve permitir que os próximos 3 caracteres sejam possíveis.
        /// Exemplo:
        /// a&123: aceita a1 a2 a3
        /// </summary>
        [TestMethod]
        public void Exercicio1A()
        {
            var exp = new ExpressaoRegular("a&123");
            Assert.IsTrue(exp.Validar("a1"));
            Assert.IsTrue(exp.Validar("a2"));
            Assert.IsTrue(exp.Validar("a3"));
            Assert.IsFalse(exp.Validar("a"));
            Assert.IsFalse(exp.Validar("123"));
        }

        /// <summary>
        /// O exercício 1 requer a implementação do operador & que deve permitir que os próximos 3 caracteres sejam possíveis.
        /// Exemplo:
        /// a&123: aceita a1 a2 a3
        /// </summary>
        [TestMethod]
        public void Exercicio1B()
        {
            var exp = new ExpressaoRegular("busca&abc&123");
            Assert.IsTrue(exp.Validar("buscaa1"));
            Assert.IsTrue(exp.Validar("buscab1"));
            Assert.IsTrue(exp.Validar("buscac1"));
            Assert.IsTrue(exp.Validar("buscaa2"));
            Assert.IsTrue(exp.Validar("buscab2"));
            Assert.IsTrue(exp.Validar("buscac2"));
            Assert.IsTrue(exp.Validar("buscaa3"));
            Assert.IsTrue(exp.Validar("buscab3"));
            Assert.IsTrue(exp.Validar("buscac3"));
            Assert.IsFalse(exp.Validar("buscaab"));
            Assert.IsFalse(exp.Validar("buscabb"));
            Assert.IsFalse(exp.Validar("busca"));
        }

        /// <summary>
        /// Independente da localização da expressão regular no meio da palavra ela deve ser encontrada.
        /// Ou seja, deve-se considerar todas as possíveis substrings dentro da palavra.
        /// </summary>
        [TestMethod]
        public void Exercicio2A()
        {
            var exp = new ExpressaoRegular("a*b+");
            Assert.IsTrue(exp.Validar("meu teste tem b entao funciona"));
            Assert.IsTrue(exp.Validar("ja comeu abobora?"));
            Assert.IsTrue(exp.Validar("vou me embora"));
            Assert.IsFalse(exp.Validar("Castele só"));
            Assert.IsFalse(exp.Validar("maaaaaaaaaaaaaaaaaano"));
        }

        /// <summary>
        /// Independente da localização da expressão regular no meio da palavra ela deve ser encontrada.
        /// Ou seja, deve-se considerar todas as possíveis substrings dentro da palavra.
        /// </summary>
        [TestMethod]
        public void Exercicio2B()
        {
            var exp = new ExpressaoRegular("teste+");
            Assert.IsTrue(exp.Validar("meu teste tem b entao funciona"));
            Assert.IsTrue(exp.Validar("quantos testes iremos fazer hoje?"));
            Assert.IsTrue(exp.Validar("já fez o testeee?"));
            Assert.IsFalse(exp.Validar("Castele só"));
            Assert.IsFalse(exp.Validar("test"));
        }

        /// <summary>
        /// Considerar o operador pipe como um divisor de expressões regulares, permitindo que qualquer parte seja aceita.
        /// Por exemplo, a expressãao teste|test|testee deve reconhecer qualquer uma das 3 palavras (teste, test e testee)
        /// </summary>
        [TestMethod]
        public void Exercicio3A()
        {
            var exp = new ExpressaoRegular("a*b+|a+b*|cb*");
            Assert.IsTrue(exp.Validar("bbbbbbbbb"));
            Assert.IsTrue(exp.Validar("aaaaaaaaa"));
            Assert.IsTrue(exp.Validar("abbbb"));
            Assert.IsTrue(exp.Validar("cccccc"));
            Assert.IsTrue(exp.Validar("cbbbbb"));
            Assert.IsFalse(exp.Validar("dddd"));
            Assert.IsFalse(exp.Validar("teste"));
        }

    }
}
