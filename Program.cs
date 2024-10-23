namespace SkllFactory.HomeWork.Mod5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = GetUserData();
            ShowUserData(user);

            Console.ReadKey();
        }

        /// <summary>
        /// Вывод в консоль заполненной анкеты пользователя.
        /// </summary>
        /// <param name="user"></param>
        private static void ShowUserData((string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) user)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Имя: {0}:", user.FirstName);
            Console.WriteLine("Фамилия: {0}:", user.LastName);
            Console.WriteLine("Возраст: {0}:", user.Age);
            if (user.HasPet)
            {
                Console.WriteLine("Питомцев: {0}", user.PetCount);
                Console.WriteLine("Их клички:");
                foreach (var item in user.PetNames)
                {
                    Console.WriteLine("- " + item);
                }
            }
            else
            {
                Console.WriteLine("Питомцев нет");
            }
            Console.WriteLine("Люимых цветов: {0}", user.FavColorsCount);
            foreach (var item in user.FavColors)
            {
                    Console.WriteLine("- " + item);
            }
        }

        /// <summary>
        /// Заполнение анкеты пользователя. Возращает кортеж с данными:
        /// - Имя
        /// - Фамилия
        /// - Возраст
        /// - Наличие питомца/ев, их количество, клички
        /// - Количество любимых цветов
        /// - Список любимых цветов.
        /// </summary>
        /// <returns></returns>
        private static (string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) GetUserData()
        {
            (string FirstName, string LastName, double Age, bool HasPet, int PetCount, string[] PetNames, int FavColorsCount, string[] FavColors) user = new();
            Console.WriteLine("Приветствуем Вас, новый пользователь! Расскажите, пожалуйста, о себе:");

            user.FirstName = GetStringDataFromKeyBoard("Введите имя:");
            user.LastName = GetStringDataFromKeyBoard("Введите фамилию:");
            user.Age = GetDoubleDataFromKeyBoard("Введите Ваш возраст:");
            GetPetInformation(out user.HasPet, out user.PetCount, out user.PetNames);
            GetFavColorsInformation(out user.FavColorsCount, out user.FavColors);

            return user;
        }

        /// <summary>
        /// Получение информации о любимых цветах.
        /// </summary>
        /// <param name="favColorCount"></param>
        /// <param name="favColors"></param>
        private static void GetFavColorsInformation(out int favColorCount, out string[] favColors)
        {
            favColorCount = GetIntDataFromKeyBoard("Введите количество любимых цветов:");
            favColors = new string[favColorCount];
            for (int i = 0; i < favColorCount; i++)
            {
                favColors[i] = GetStringDataFromKeyBoard($"Назовите цвет {i + 1}");
            }

        }

        /// <summary>
        /// Получение информации о питомцах.
        /// </summary>
        /// <param name="hasPet"></param>
        /// <param name="petCount"></param>
        /// <param name="petNames"></param>
        private static void GetPetInformation(out bool hasPet, out int petCount, out string[] petNames)
        {
            var notCorrected = true;
            hasPet = false;
            petCount = 0;
            petNames = Array.Empty<string>();
            while (notCorrected)
            {
                Console.WriteLine("Имеется ли у Вас питомец? (да/нет):");
                var hasPetString = Console.ReadLine();
                switch (hasPetString)
                {
                    case "да":
                        hasPet = true;
                        petCount = GetIntDataFromKeyBoard("Введите количество питомцев:");
                        petNames = GetPetNames(petCount);
                        notCorrected = false;
                        break;
                    case "нет":
                        notCorrected = false;
                        break;
                    default:
                        PrintNotCorrected();
                        break;
                }
            }
        }

        /// <summary>
        /// Получение имен питомцев.
        /// </summary>
        /// <param name="petCount"></param>
        /// <returns></returns>
        private static string[] GetPetNames(int petCount)
        {
            var petNames = new string[petCount];
            for (int i = 0; i < petCount; i++)
            {
                petNames[i] = GetStringDataFromKeyBoard($"Введите имя питомца {i + 1}:");
            }

            return petNames;
        }

        /// <summary>
        /// Получение строки с клавиатуры, проверка на пустой ввод.
        /// </summary>
        /// <param name="GetMessage"></param>
        /// <returns></returns>
        private static string GetStringDataFromKeyBoard(string GetMessage)
        {
            var responseMessage = string.Empty;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                responseMessage = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(responseMessage))
                {
                    notCorrected = false;
                }
                else
                {
                    PrintNotCorrected();
                }
            }

            return responseMessage;
        }

        /// <summary>
        /// Получение целого числа с клавиатуры,
        /// проверка введения целого числа,
        /// проверка на значение (не должно быть равно 0).
        /// </summary>
        /// <param name="GetMessage"></param>
        /// <returns></returns>
        private static int GetIntDataFromKeyBoard(string GetMessage)
        {
            var responceMessage = 0;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                notCorrected = !int.TryParse(Console.ReadLine(), out responceMessage);
                if (notCorrected)
                {
                    PrintNotCorrected();
                }
                else
                {
                    if (responceMessage == 0)
                    {
                        notCorrected = true;
                    }
                }
            }
            return responceMessage;
        }

        /// <summary>
        /// Получение действительного числа с клавиатуры,
        /// проверка введения действительного числа,
        /// проверка на значение (не должно быть равно 0).
        /// </summary>
        /// <param name="GetMessage"></param>
        /// <returns></returns>
        private static double GetDoubleDataFromKeyBoard(string GetMessage)
        {
            var responceMessage = 0.0;
            var notCorrected = true;
            while (notCorrected)
            {
                Console.WriteLine(GetMessage);
                notCorrected = !double.TryParse(Console.ReadLine(), out responceMessage);
                if (notCorrected)
                {
                    PrintNotCorrected();
                }
                else
                {
                    if (responceMessage == 0)
                    {
                        notCorrected = true;
                    }
                }
            }
            return responceMessage;
        }

        /// <summary>
        /// Вывод в консоль уведомление о некоррекном вводе.
        /// </summary>
        private static void PrintNotCorrected()
        {
            Console.WriteLine("Веден некорректный ответ!");
        }
    }
}

