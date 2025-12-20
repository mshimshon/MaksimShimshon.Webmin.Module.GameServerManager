using GameServerManager.Core.Abstractions.Dashboard.Menu.Contracts;

namespace GameServerManager.Core.Abstractions.Dashboard.Menu;

public interface IDashboardMenu
{
    ICollection<MenuContract> GetItems();
    ICollection<MenuSectionContract> GetSections();
    MenuContract GetItem(string id);
    MenuSectionContract GetSection(string id);
    bool HasItem(string id);
    bool HasSection(string id);
    void AddItems(params MenuContract[] menuContracts);
    void AddSections(params MenuSectionContract[] menuSections);
    void RemoveItems(params string[] ids);
    void RemoveSections(params string[] ids);
    void UpdateItems(params MenuContract[] menuContracts);
    void UpdateSections(params MenuSectionContract[] menuContracts);
}
