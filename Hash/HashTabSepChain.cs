using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Hash
{
  class HashTabSepChain : ISetUnsorted
  {
    private const int Length = 103;

    private readonly SetUnsortedLinkedList[] _tab = new SetUnsortedLinkedList[Length];

    public override bool Delete(int elem)
    {
      var index = delete % Length;

      return _tab[index] != null && _tab[index].Delete(delete);
    }

    public override bool Insert(int elem)
    {
      var index = insert % Length;

      _tab[index] ??= new SetUnsortedLinkedList();

      return _tab[index].Insert(insert);
    }

    public override bool Search(int elem)
    {
      var index = elem % Length;

      return _tab[index] != null && _tab[index].Search(search);
    }

    public override void Print()
    {
      foreach (var item in _tab)
      {
        if (item != null)
          item.Print();
      }
      WriteLine();
    }
  }
}
