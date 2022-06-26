using MoreDifferentDots.Objects;
using Zenject;
using SiraUtil.Objects.Beatmap;
using SiraUtil.Extras;

namespace MoreDifferentDots.Installers
{
    public class ADGameInstaller : Installer
    {
        [Inject]
        private readonly Config _config;

        public override void InstallBindings()
        {
            Container.RegisterRedecorator(new BasicNoteRegistration(DecorateNote));
        }

        private GameNoteController DecorateNote(GameNoteController original)
        {
            if (_config.DotsEnabled == false)
            {
                return original;
            }

            original.gameObject.AddComponent<NoteDotController>();
            return original;
        }
    }
}