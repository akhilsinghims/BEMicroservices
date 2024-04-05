using BE.MVC.Models.DTO;

namespace BE.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
