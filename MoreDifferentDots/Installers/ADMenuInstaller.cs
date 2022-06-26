using MoreDifferentDots.UI;
using Zenject;

namespace MoreDifferentDots.Installers
{
    class ADMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DotTab>().FromNewComponentOnRoot().AsSingle();
        }
    }
}
