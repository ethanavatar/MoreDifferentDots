using Zenject;
using InstallerIHardlyKnowHer = Zenject.Installer;

namespace MoreDifferentDots.Installers
{
    public class ADAppInstaller : InstallerIHardlyKnowHer
    {
        private readonly Config _config;

        public ADAppInstaller(Config config) => _config = config;

        public override void InstallBindings()
        {
            Container.BindInstance(_config);
        }
    }
}
//nya :3
// a