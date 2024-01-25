namespace THEJOB.Cachorro.Domain
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public string Nome { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizacao { get; set; }
    }
}