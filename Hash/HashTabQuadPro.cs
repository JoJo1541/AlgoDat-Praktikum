using System;
using static System.Console;

namespace Praktikum.Hash
{
    class HashTabQuadPro : HashBase
    {
        private const int MaxProbingDistance = (Length - 1) / 2;

        private readonly int?[] _tab = new int?[Length];

        private int _current, _next;

        public override bool Delete(int elem)
        {
            if (!Search(elem))
                return false;

            if (_tab[_next] == null)
                _tab[_current] = null; //bedeutet freigegeben
            else
                _tab[_current] = -1; //bedeutet gelöscht

            return true;
        }

        public override bool Insert(int elem)
        {
            if (Search(elem))
                return false;

            if (_tab[_current] != null && _tab[_current] != -1)
                return false;

            _tab[_current] = elem;

            return true;
        }

        public override bool Search(int elem)
        {
            var index = HashFunc(elem);

            _current = index;

            if (_tab[_current] == null)
                return false;

            if (_tab[_current] == elem)
            {
                _next = (_current + 1) % Length;

                return true;
            }

            int probingDistance = 1, probingDirection = 1, tmp;

            do
            {
                var rawIndex = index + probingDistance * probingDistance * probingDirection;

                while (rawIndex < 0)
                    rawIndex += Length;

                tmp = rawIndex % Length;

                if (_tab[tmp] == elem || (_tab[_current] != -1 && (_tab[tmp] == -1 || _tab[tmp] == null)))
                    _current = tmp;

                probingDirection *= -1;

                if (probingDirection == 1)
                    probingDistance++;
            }
            while (_tab[tmp] != null && _tab[tmp] != elem && probingDistance <= MaxProbingDistance);

            _next = ((index + probingDistance * probingDistance * probingDirection) + Length) % Length;

            return _tab[_current] == elem;
        }

        public override void Print()
        {
            var counter = 0;

            for (var i = 0; i < Length; i++)
            {
                var def = ForegroundColor;

                if (_tab[i] != null && _tab[i] % Length != i)
                    ForegroundColor = ConsoleColor.DarkGreen;

                Write(_tab[i] != null ? $"{_tab[i],3} " : " X  ");

                ForegroundColor = def;

                if (++counter % 10 == 0)
                    WriteLine();
            }

            WriteLine();
        }
    }
}
