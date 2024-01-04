namespace THEJOB.Cachorro.Domain
{
    public class Cachorro : BaseEntity<Guid>
    {
        public string Nome { get; init; }
        public DateTime Nascimento { get; init; }
        public List<Vacinas> Vacinas { get; private set; }
        public void Vacinar(Vacinas vacina)
        {
            Vacinas.Add(vacina);
        }
    }

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
}