using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacaoAutomatos.Classes;

namespace TesteProva
{
    [TestClass]
    public class Exercicios
    {

        /// <summary>
        /// O exercício 1 requer a implementação do operador & que deve permitir que os próximos 3 caracteres sejam intercalados 0 ou mais vezes.
        /// Exemplo:
        /// a&123: aceita a1 a2 a3
        /// </summary>
        [TestMethod]
        public void Exercicio1A()
        {
            var exp = new ExpressaoRegular("a&123");
            Assert.IsTrue(exp.Validar("a123"));
            Assert.IsTrue(exp.Validar("a123123"));
            Assert.IsTrue(exp.Validar("a"));
            Assert.IsFalse(exp.Validar("a1"));
            Assert.IsFalse(exp.Validar("a12312"));
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
            Assert.IsTrue(exp.Validar("busca123123"));
            Assert.IsTrue(exp.Validar("buscaabcabc"));
            Assert.IsTrue(exp.Validar("buscaabc123123"));
            Assert.IsTrue(exp.Validar("buscaabcabc123123"));
            Assert.IsFalse(exp.Validar("buscaaabc1"));
            Assert.IsFalse(exp.Validar("buscabb"));
            Assert.IsTrue(exp.Validar("busca"));
        }

        /// <summary>
        /// Considerar os parâmetros de inicio (^) e fim de string  ($). Quando nenhum deles for apresentado, deverá se considerar que ambos estão presentes.
        /// </summary>
        [TestMethod]
        public void Exercicio2A()
        {
            var exp = new ExpressaoRegular("ab");
            Assert.IsTrue(exp.Validar("ab"));
            Assert.IsFalse(exp.Validar("cabana"));
        }

        /// <summary>
        /// Considerar os parâmetros de inicio (^) e fim de string  ($). Quando nenhum deles for apresentado, deverá se considerar que ambos estão presentes.
        /// </summary>
        [TestMethod]
        public void Exercicio2B()
        {
            var exp = new ExpressaoRegular("^ab");
            Assert.IsTrue(exp.Validar("abobora"));
            Assert.IsTrue(exp.Validar("abraço"));
            Assert.IsTrue(exp.Validar("abdicar"));
            Assert.IsFalse(exp.Validar("cabana"));
            Assert.IsFalse(exp.Validar("cabaré"));
        }

        /// <summary>
        /// Considerar os parâmetros de inicio (^) e fim de string  ($). Quando nenhum deles for apresentado, deverá se considerar que ambos estão presentes.
        /// </summary>
        [TestMethod]
        public void Exercicio2C()
        {
            var exp = new ExpressaoRegular("sa$");
            Assert.IsTrue(exp.Validar("casa"));
            Assert.IsTrue(exp.Validar("arrasa"));
            Assert.IsTrue(exp.Validar("corsa"));
            Assert.IsFalse(exp.Validar("sal"));
            Assert.IsFalse(exp.Validar("salmonela"));
        }

        /// <summary>
        /// Considerar a existência de subexpressões (entre parenteses). Estas sub-expressões sempre serão acompanhadas de um operador de repetição (*, + ou ?)
        /// </summary>
        [TestMethod]
        public void Exercicio3A()
        {
            var exp = new ExpressaoRegular("c(ab+)*d");
            Assert.IsTrue(exp.Validar("cd"));
            Assert.IsTrue(exp.Validar("cabd"));
            Assert.IsTrue(exp.Validar("cabababd"));
            Assert.IsTrue(exp.Validar("cabbbbbabd"));
            Assert.IsFalse(exp.Validar("cad"));
            Assert.IsFalse(exp.Validar("cabad"));
        }

    }
}
