namespace THEJOB.Cachorro.Domain
{
    public class Cachorro : BaseEntity<Guid>
    {
        public string Nome { get; init; }
        public DateTime Nascimento { get; init; }
        public bool Adotado { get; set; }
        public PelagemType Pelagem { get; set; }
        public float Peso { get; set; }

        [Flags]
        public enum Vacinas
        {
            None = 0,
            Raiva,
            V8,
            V10,
            TosseDosCanis,
            Leishmaniose,
            Giardia,
            GripeCanina,
            Cinomose,
            Parvovirose,
            Coronavirose,
            Adenovirose,
            HepatiteInfecciosaCanina,
            Parainfluenza,
            Leptospirose,
            BordetellaBronchiseptica
        }

        [Flags]
        public enum PelagemType
        {
            None = 0,
            Curto,
            Medio,
            Longo
        }
    }
}