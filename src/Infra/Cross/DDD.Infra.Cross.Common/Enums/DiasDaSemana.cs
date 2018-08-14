using System;

namespace DDD.Infra.Cross.Common.Enums
{
    [Flags]
    public enum DiasDaSemana
    {
        Domingo = 1, // 0x00000001
        Segunda = 2, // 0x00000010
        Terca = 4,   // 0x00000100
        Quarta = 8,  // 0x00001000
        Quinta = 16, // 0x00010000
        Sexta = 32,  // 0x00100000
        Sabado = 64  // 0x01000000
    }
}
