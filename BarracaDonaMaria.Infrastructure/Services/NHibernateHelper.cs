using BarracaDonaMaria.Infrastructure.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace BarracaDonaMaria.Infrastructure.Services;

public class NHibernateHelper
{
    private static readonly ISessionFactory _sessionFactory;

    static NHibernateHelper() =>
        _sessionFactory = FluentConfigure();

    public static ISession GetCurrentSession() =>
        _sessionFactory.GetCurrentSession();

    public static void BeginTransaction()
    {
        var _session = _sessionFactory.OpenSession();
        _session.BeginTransaction();
        CurrentSessionContext.Bind(_session);
    }

    public static async Task CommitAsync()
    {
        var _session = _sessionFactory.GetCurrentSession();
        await _session.GetCurrentTransaction()?.CommitAsync();
    }

    public static async Task RollbackAsync()
    {
        var _session = _sessionFactory.GetCurrentSession();
        await _session.GetCurrentTransaction()?.RollbackAsync();
    }

    public static void CloseSessionFactory()
    {
        if (_sessionFactory != null)
        {
            _sessionFactory.Close();
        }
    }

    public static ISessionFactory FluentConfigure()
    {
        ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(ConnectionStrings.GetDefaultConnection())
                .ShowSql()
                )
            .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ClienteMap>())
            .CurrentSessionContext<AsyncLocalSessionContext>()
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();

        return sessionFactory;
    }

}
