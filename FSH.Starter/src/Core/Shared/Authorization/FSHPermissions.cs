using System.Collections.ObjectModel;

namespace FSH.Starter.Shared.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Fundraiser = nameof(Fundraiser);
    public const string Accounts = nameof(Accounts);
    public const string Campaigns = nameof(Campaigns);
    public const string Donations = nameof(Donations);
    public const string Configurations = nameof(Configurations);
    public const string CampaignStudents = nameof(CampaignStudents);
    public const string Students = nameof(Students);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users),
        new("Search Users", FSHAction.Search, FSHResource.Users),
        new("Create Users", FSHAction.Create, FSHResource.Users),
        new("Update Users", FSHAction.Update, FSHResource.Users),
        new("Delete Users", FSHAction.Delete, FSHResource.Users),
        new("Export Users", FSHAction.Export, FSHResource.Users),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles),
        new("View Roles", FSHAction.View, FSHResource.Roles),
        new("Create Roles", FSHAction.Create, FSHResource.Roles),
        new("Update Roles", FSHAction.Update, FSHResource.Roles),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products, IsBasic: true),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        // Fundraiser permissions
        new FSHPermission("View Fundraisers", FSHAction.View, FSHResource.Fundraiser),
        new FSHPermission("Create Fundraisers", FSHAction.Create, FSHResource.Fundraiser),
        new FSHPermission("Update Fundraisers", FSHAction.Update, FSHResource.Fundraiser),
        new FSHPermission("Delete Fundraisers", FSHAction.Delete, FSHResource.Fundraiser),

        // Accounts permissions
        new FSHPermission("View Accounts", FSHAction.View, FSHResource.Accounts),
        new FSHPermission("Create Accounts", FSHAction.Create, FSHResource.Accounts),
        new FSHPermission("Update Accounts", FSHAction.Update, FSHResource.Accounts),
        new FSHPermission("Delete Accounts", FSHAction.Delete, FSHResource.Accounts),
        new("Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true),

        // Campaigns permissions
        new FSHPermission("View Campaigns", FSHAction.View, FSHResource.Campaigns),
        new FSHPermission("Create Campaigns", FSHAction.Create, FSHResource.Campaigns),
        new FSHPermission("Update Campaigns", FSHAction.Update, FSHResource.Campaigns),
        new FSHPermission("Delete Campaigns", FSHAction.Delete, FSHResource.Campaigns),

        // Donations permissions
        new FSHPermission("View Donations", FSHAction.View, FSHResource.Donations),
        new FSHPermission("Create Donations", FSHAction.Create, FSHResource.Donations),
        new FSHPermission("Update Donations", FSHAction.Update, FSHResource.Donations),
        new FSHPermission("Delete Donations", FSHAction.Delete, FSHResource.Donations),

        // Configurations permissions
        new FSHPermission("View Configurations", FSHAction.View, FSHResource.Configurations),
        new FSHPermission("Create Configurations", FSHAction.Create, FSHResource.Configurations),
        new FSHPermission("Update Configurations", FSHAction.Update, FSHResource.Configurations),
        new FSHPermission("Delete Configurations", FSHAction.Delete, FSHResource.Configurations),

        // CampaignStudents permissions
        new FSHPermission("View CampaignStudents", FSHAction.View, FSHResource.CampaignStudents),
        new FSHPermission("Create CampaignStudents", FSHAction.Create, FSHResource.CampaignStudents),
        new FSHPermission("Update CampaignStudents", FSHAction.Update, FSHResource.CampaignStudents),
        new FSHPermission("Delete CampaignStudents", FSHAction.Delete, FSHResource.CampaignStudents),

        // Students permissions
        new FSHPermission("View Students", FSHAction.View, FSHResource.Students),
        new FSHPermission("Create Students", FSHAction.Create, FSHResource.Students),
        new FSHPermission("Update Students", FSHAction.Update, FSHResource.Students),
        new FSHPermission("Delete Students", FSHAction.Delete, FSHResource.Students)
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
