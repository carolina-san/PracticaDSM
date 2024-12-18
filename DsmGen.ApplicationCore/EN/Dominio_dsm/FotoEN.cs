
using System;
// Definición clase FotoEN
namespace DsmGen.ApplicationCore.EN.Dominio_dsm
{
public partial class FotoEN
{




/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo archivo
 */
private string archivo;



/**
 *	Atributo alt
 */
private string alt;










public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Archivo {
        get { return archivo; } set { archivo = value;  }
}



public virtual string Alt {
        get { return alt; } set { alt = value;  }
}





public FotoEN()
{
}



public FotoEN(int id, string archivo, string alt
              )
{
        this.init (Id, archivo, alt);
}


public FotoEN(FotoEN foto)
{
        this.init (foto.Id,  foto.Archivo, foto.Alt);
}

private void init (int id
                   , string archivo, string alt)
{
        this.Id = id;


   

        this.Archivo = archivo;

        this.Alt = alt;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FotoEN t = obj as FotoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
