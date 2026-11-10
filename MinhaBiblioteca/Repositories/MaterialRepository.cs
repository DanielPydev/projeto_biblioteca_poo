using MinhaBiblioteca.models;

namespace MinhaBiblioteca.Repositories;

public class MaterialRepository : IMaterialRepository
{
    private Dictionary<int, MaterialBiblioteca> _materiais;

    public MaterialRepository()
    {
        _materiais = new Dictionary<int, MaterialBiblioteca>();

        var livro = new Livro { Titulo = "Harry Potter e a pedra filosofal", anoPublicacao = 1998, Autor = "J. K. Rowling", Paginas = 264 };
        Adicionar(livro);

        var Revista = new Revista { Titulo = "Tecnologia e Inovação", anoPublicacao = 2023, Edicao = 15, MesPublicacao = 10 };
        Adicionar(Revista);
    }

    private int GerarNovoId()
    {
        if (_materiais.Count == 0)
            return 1;

        return _materiais.Keys.Max() + 1;
    }

    public IEnumerable<MaterialBiblioteca> ObterTodos()
    {
        return _materiais.Values;
    }

    public MaterialBiblioteca? ObterPorId(int id)
    {
        if (_materiais.ContainsKey(id))
            return _materiais[id];
        return null;
    }

    public MaterialBiblioteca Adicionar(MaterialBiblioteca material)
    {
        material.Id = GerarNovoId();
        _materiais.Add(material.Id, material);
        return material;
    }

    public bool Atualizar(int id, MaterialBiblioteca material)
    {
        if (!_materiais.ContainsKey(id))
            return false;

        material.Id = id;
        _materiais[id] = material;
        return true;
    }

    public bool Remover(int id)
    {
        return _materiais.Remove(id);
    }
}