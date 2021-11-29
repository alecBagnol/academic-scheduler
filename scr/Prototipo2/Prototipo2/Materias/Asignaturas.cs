using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstructurasLineales;

namespace Materias
{
    public class Asignatura : OperacionesAsignaturas
    {
        public int? codigo, creditos;
        public int semestre;
        public bool cursado = false;
        public string? nombreAsignatura;
        public int? codigoSede;
        public MyLinkedList<int>? programasAsociados;
        public string? componente;
        public MyLinkedList<string>? NombrePrerrequisito;
        public MyLinkedList<int>? prerrequisito;
        public MyLinkedList<int>? correquisito;
        public Asignatura()
        {
            codigo = null; nombreAsignatura = null;
            codigoSede = null; programasAsociados = null;
            correquisito = null; componente = null; prerrequisito = null;
        }
        public Asignatura( int codigo,
                          string nombreAsignatura,
                          int creditos,
                          int codigoSede,
                          MyLinkedList<int> programasAsociados,
                          string componente,
                          MyLinkedList<string>? NombrePrerrequisito,
                          MyLinkedList<int> prerrequisito,
                          MyLinkedList<int> correquisito, bool cursado)
        {
            if (string.IsNullOrEmpty(nombreAsignatura))
            {
                throw new ArgumentException($"'{nameof(nombreAsignatura)}' cannot be null or empty.", nameof(nombreAsignatura));
            }

            if (string.IsNullOrEmpty(componente))
            {
                throw new ArgumentException($"'{nameof(componente)}' cannot be null or empty.", nameof(componente));
            }
            this.codigo = codigo;
            this.nombreAsignatura = nombreAsignatura;
            this.creditos = creditos;
            this.codigoSede = codigoSede;
            this.programasAsociados = programasAsociados;
            this.componente = componente;
            this.correquisito = correquisito;
            this.prerrequisito = prerrequisito;
            this.NombrePrerrequisito = NombrePrerrequisito;
            this.cursado= cursado;
        }
        public void MostrarPrerrequisitos()
        {
            if (prerrequisito?.IsEmpty() == false)
            {
                for (int i = 0; i < prerrequisito.GetLength(); i++)
                {
                    Console.WriteLine("Pre-requisitos: ");
                    Console.Write(prerrequisito.GetValue(i) + "  ");
                }
                Console.WriteLine();
            }

        }
        public void MostrarProgramaAsociado()
        {
            if (programasAsociados?.IsEmpty() == false)
            {
                int n = programasAsociados.GetLength() % 4;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(programasAsociados.GetValue(i) + "  ");
                }
                Console.WriteLine();
            }
        }

        public void AñadirPrerrequisito(int dato)
        {
            prerrequisito?.AddToEnd(dato);
        }
        public bool TienePrerrequisito() { return prerrequisito.IsEmpty(); }
        public string mostrarNombre(int codigo2)
        {
            if (codigo == codigo2) { return nombreAsignatura; }
            else { return ""; }
        }
    }
}
