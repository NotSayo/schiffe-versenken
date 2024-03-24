using System.Runtime.CompilerServices;

namespace ShipDLL;

public class ModalData
{
    public string Title { get; set; }
    public string Lead { get; set; }
    public string Description { get; set; }
    public string ExtraInformations { get; set; }
    public bool isVisible { get; set; }
    public EModalButtons Buttons { get; set; }

    public ModalData()
    {
        Title = "";
        Lead = "";
        Description = "";
        ExtraInformations = "";
        isVisible = false;
        Buttons = EModalButtons.Confirm;
    }
    
    public ModalData(string title, string lead, string description, string extraInformations, EModalButtons buttons)
    {
        Title = title;
        Lead = lead;
        Description = description;
        ExtraInformations = extraInformations;
        Buttons = buttons;
    }
    
    public void HideModal()  => isVisible = false;
    public void ShowModal() => isVisible = true;
}