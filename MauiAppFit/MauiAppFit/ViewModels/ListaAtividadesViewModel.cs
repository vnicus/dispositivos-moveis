using MauiAppFit.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiAppFit.ViewModels
{
    public class ListaAtividadesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * Pegar o que foi digitado na SearchBar...
         */
        public string? ParametroBusca { get; set; }

        /**
         *  Gerenciar a RefreshView
         */
        bool estaAtualizando = false;
        public bool EstaAtualizando
        {
            get => estaAtualizando;
            set
            {
                estaAtualizando = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EstaAtualizando"));
            }
        }

        /**
         * Coleção que armazena as atividades cadastradas.
         */
        ObservableCollection<Atividade> listaAtividades = new();
        public ObservableCollection<Atividade> ListaAtividades
        {
            get => listaAtividades;
            set => listaAtividades = value;
        }

        public ICommand AtualizarLista
        {
            get
            {
                return new Command(async () =>
                {                  
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;
                        List<Atividade> tmp = await App.Database.GetAllRows();
                        ListaAtividades.Clear();
                        tmp.ForEach(i => ListaAtividades.Add(i));

                        Debug.WriteLine("-----------------------------");
                        Debug.WriteLine("Chegou AtualizarLista");
                        Debug.WriteLine(tmp.Count);
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlertAsync("Ops", ex.Message, "OK");
                    } finally
                    {
                        EstaAtualizando = false;
                    } // Fecha try-catch-finally
                }); // Fecha return
            } // Fecha get
        } // Fecha AtualizarLista

        public ICommand Buscar
        {
            get
            {
                return new Command(async () =>
                {                
                    try
                    {
                        if (EstaAtualizando)
                            return;                        

                        EstaAtualizando = true;
                        List<Atividade> tmp = await App.Database.Search(ParametroBusca);
                        ListaAtividades.Clear();
                        tmp.ForEach(i => ListaAtividades.Add(i));

                        Debug.WriteLine("-----------------------------");
                        Debug.WriteLine("Chegou");
                        Debug.WriteLine(tmp.Count);
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlertAsync("Ops", ex.Message, "OK");
                    } finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        } // Fecha Command Buscar

        public ICommand AbrirDetalhes
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    string uri = $"//CadastroAtividade?parametro_id={id}";
                    await Shell.Current.GoToAsync(uri);
                });
            }
        } // Fecha Command AbrirDetalhes

        public ICommand Remover
        {
            get
            {
                return new Command<int>(async (int id) =>
                {
                    try
                    {
                        bool conf = await Shell.Current.DisplayAlertAsync(
                            "Tem Certeza?", "Excluir?", "Sim", "Não");

                        if(conf)
                        {
                            await App.Database.Delete(id);
                            AtualizarLista.Execute(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlertAsync("Ops", ex.Message, "OK");
                    } finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        } // Fecha Command Remover


    } // Fecha classe
} // Fecha namespace
