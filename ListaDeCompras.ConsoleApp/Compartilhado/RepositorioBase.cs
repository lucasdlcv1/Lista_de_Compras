namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase
{
    private readonly List<TEntidade> registros = new List<TEntidade>();

    public void Cadastrar(TEntidade novoRegistro)
    {
        registros.Add(novoRegistro);
    }

    public bool Editar(int idSelecionado, TEntidade entidadeAtualizada)
    {
        TEntidade? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        TEntidade? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        registros.Remove(entidadeSelecionada);
        return true;
    }

    public TEntidade? SelecionarPorId(int idSelecionado)
    {
        foreach (TEntidade entidade in registros)
        {
            if (entidade.Id == idSelecionado)
                return entidade;
        }

        return null;
    }

    public List<TEntidade> SelecionarTodos()
    {
        return registros;
    }
}
