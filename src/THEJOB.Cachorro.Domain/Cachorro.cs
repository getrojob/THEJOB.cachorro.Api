﻿namespace THEJOB.Cachorro.Domain
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
            Raiva = 1,
            V8 = 2,
            V10 = 3,
            TosseDosCanis = 5,
            Leishmaniose = 6,
            Giardia = 7,
            GripeCanina = 8,
            Cinomose = 10,
            Parvovirose = 11,
            Coronavirose = 12,
            Adenovirose = 13,
            HepatiteInfecciosaCanina = 14,
            Parainfluenza = 15,
            Leptospirose = 16,
            BordetellaBronchiseptica = 17
        }

        [Flags]
        public enum PelagemType
        {
            None = 0,
            Curto = 1,
            Medio = 2,
            Longo = 3
        }
    }
}