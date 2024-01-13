namespace THEJOB.Cachorro.Domain
{
    public class Cachorro : BaseEntity<Guid>
    {
        public string Nome { get; init; }
        public DateTime Nascimento { get; init; }
        public bool Adotado { get; set; }
        //public List<Vacinas> Vacinas { get; private set; } = new List<Vacinas>();
        public string Pelagem { get; set; }
        public float Peso { get; set; }
        //public void Vacinar(Vacinas vacinas)
        //{
        //    Vacinas.Add(vacinas);
        //}
    }

    [Flags]
    public enum Vacinas
    {
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
    public enum Pelagem
    {
        Curto,
        Medio,
        Longo
    }
}