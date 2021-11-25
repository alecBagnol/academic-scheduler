namespace EstructurasLineales
{
    public class MyStack<T>:MyLinkedList<T>
    {
        public MyLinkedList<T> Stack ;
        public MyStack(): base (){
            this.Stack = new MyLinkedList<T>();
        }
        public void push(T data){
            AddToBeginning(data);
        }
        public T pop(){
            T value=Remove(0);
            Console.WriteLine("Valor removido: {0}",value);
            return value;
        }
        public T peek(){
            return GetValue(0);
        }
    }
}