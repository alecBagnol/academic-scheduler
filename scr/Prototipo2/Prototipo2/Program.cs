using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EstructurasLineales;
using Materias;

namespace Main
{
    class MateriasMain
    {

        public static void Menu()
        {   
            Console.WriteLine("1. Organizar Asignaturas");
            Console.WriteLine("2. Selecciona asignaturas para generar rutas");
            Console.WriteLine("3. Buscar asignatura");
            Console.WriteLine("4. Cargar un archivo para ver mis asignaturas");
            Console.WriteLine("Que deseas hacer : ");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    pedirAsignaturas();
                    sw.Stop();
                    Console.WriteLine($"Tiempo: {sw.Elapsed.TotalMilliseconds} ms"); 
                    break;
                case "2": break;
                case "3": break;
                default: Console.WriteLine("Your input is not valid"); Menu(); break;
            }
        }
        public static void pedirAsignaturas()
        {
            MyQueue<Asignatura> asignaturas = new MyQueue<Asignatura>();
            //Console.WriteLine("¿Cuantas asignaturas quieres planificar ?");
            //string numero = Console.ReadLine();
            int n = 10; //Aqui le cambia por el numero de datos a generar
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine("Nombre de la asignatura:");
                string nombreAsignatura = Console.ReadLine().ToUpper(); //cambiele por un nombre como ""+i
                //Console.WriteLine("Nombre de prerrequisitos(separados por comas):");
                string prerrequisito = Console.ReadLine().ToUpper().Trim();//Si quiere metale algo asi como ""+(n-i)+","+ (n-i-i)) --->Para que le meta dos prerequisitos a cada asignatura pero metale un if que si i=n-1 solo le meta un prerrequisito
                MyLinkedList<string> prerrequisitos = new MyLinkedList<string>();
                Asignatura aux = new Asignatura(); aux.nombreAsignatura = nombreAsignatura;
                foreach (string materia in prerrequisito.Split(","))
                {
                    prerrequisitos.AddToEnd(materia.Trim());
                }
                aux.NombrePrerrequisito = prerrequisitos;
                asignaturas.enqueue(aux);
            }
            Organizar(asignaturas);
        }
        public static int AsignarSemestre(Asignatura asignatura, MyLinkedList<Asignatura> Asignaturas, MyQueue<Asignatura> Asignaturas2)
        {
            if (asignatura.NombrePrerrequisito == null || asignatura.NombrePrerrequisito.GetValue(0) == "")
            {
                return 1;
            }
            else
            {
                int n = asignatura.NombrePrerrequisito.GetLength();
                int semestre = 0;
                for (int j = 0; j < n; j++)
                {
                    Asignatura aux = buscarAsignatura(asignatura.NombrePrerrequisito.GetValue(j), Asignaturas);
                    if (aux == null) { aux = buscarAsignatura(asignatura.NombrePrerrequisito.GetValue(j), Asignaturas2); }
                    int semestreAux = AsignarSemestre(aux, Asignaturas, Asignaturas2);
                    if (semestre == 0 || semestre < semestreAux) { semestre = semestreAux; }
                }
                return semestre + 1;
            }
        }

        public static void Organizar(MyQueue<Asignatura> Asignaturas)
        {
            MyQueue<Asignatura> Asignaturas2 = new MyQueue<Asignatura>();
            /*Console.WriteLine("Introduzca la ruta del directorio donde quiere que se guarde su archivo: ");
            //string rutaArchivo = Console.ReadLine();
            //Console.WriteLine("Introduzca el nombre para su archivo:");
           //string nombreArchivo = Console.ReadLine();
            //using (StreamWriter outputFile = new StreamWriter(rutaArchivo + "\\" + nombreArchivo + ".txt"))
            {*/
                Asignatura aux1 = new Asignatura();
                for (int i = 0; i < Asignaturas.GetLength(); i++)
                {
                    aux1 = Asignaturas.dequeue(); i--;
                    Asignaturas2.enqueue(aux1);
                    aux1.semestre = AsignarSemestre(aux1, Asignaturas, Asignaturas2);
                    Console.WriteLine("Semestre " + aux1.semestre + "---" + aux1.nombreAsignatura);
                    //outputFile.WriteLine("Semestre " + aux1.semestre + "---" + aux1.nombreAsignatura);
                }
            //}


        }
        public static Asignatura buscarAsignatura(String Nombre, MyLinkedList<Asignatura> asignaturas)
        {
            int n = asignaturas.GetLength();
            Node<Asignatura> aux = asignaturas.GetHeadNode();
            for (int i = 0; i < n; i++)
            {
                if (aux.data.nombreAsignatura == Nombre)
                {
                    return aux.data;
                }
                else { aux = aux.nextNode; }
            }
            return null;
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
