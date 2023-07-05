using LocaCar.Api.Models;

namespace LocaCar.Api.Data.SeedData
{
    public class CarroDataSeeder : DataSeeder<Carro>
    {
        public CarroDataSeeder(AppDbContext dbContext) : base(dbContext)
        {
        }

        protected override List<Carro> ObterDados()
        {
            var lstCarro = new List<Carro>
            {
                new Carro("Volkswagen", "Golf", "2022", "Prata", "Hatchback", "1.4L", "Automática", 5000.2m, 35000.50m, 4, 5, "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada."),
                new Carro("Ford", "Mustang", "2021", "Vermelho", "Cupê", "5.0L", "Manual", 8000.8m, 40000.75m, 2, 4, "O Ford Mustang 2021 é um cupê icônico que combina potência e estilo em um único veículo."),
                new Carro("Toyota", "Corolla", "2020", "Branco", "Sedan", "2.0L", "Automática", 10000.5m, 25000.00m, 4, 5, "O Toyota Corolla 2020 é um sedan confiável, econômico e confortável, com tecnologia de ponta e um design elegante."),
                new Carro("Chevrolet", "Camaro", "2019", "Amarelo", "Cupê", "6.2L", "Manual", 3000.3m, 50000.25m, 2, 2, "O Chevrolet Camaro 2019 é um cupê esportivo de alto desempenho, com um motor potente e um design impressionante."),
                new Carro("Honda", "Civic", "2022", "Preto", "Sedan", "1.5L", "Automática", 7000.7m, 30000.50m, 4, 5, "O Honda Civic 2022 é um sedan confiável e eficiente, com uma reputação de durabilidade e conforto."),
                new Carro("BMW", "X5", "2021", "Prata", "SUV", "3.0L", "Automática", 15000.9m, 45000.75m, 4, 7, "O BMW X5 2021 é um SUV de luxo que combina elegância, desempenho e tecnologia avançada em um veículo espaçoso e confortável."),
                new Carro("Mercedes-Benz", "Classe C", "2020", "Azul", "Sedan", "2.0L", "Automática", 12000.6m, 40000.00m, 4, 5, "A Mercedes-Benz Classe C 2020 é um sedan de luxo com um interior sofisticado, tecnologia avançada e um desempenho impressionante."),
                new Carro("Audi", "A4", "2019", "Branco", "Sedan", "2.0L", "Automática", 9000.4m, 35000.25m, 4, 5, "O Audi A4 2019 é um sedan elegante e esportivo, com um interior luxuoso, tecnologia de ponta e um desempenho excepcional."),
                new Carro("Hyundai", "HB20", "2022", "Vermelho", "Hatchback", "1.6L", "Manual", 6000.2m, 25000.50m, 4, 5, "O Hyundai HB20 2022 é um hatchback moderno e versátil, com um design arrojado e recursos avançados de segurança e conectividade."),
                new Carro("Kia", "Sportage", "2021", "Prata", "SUV", "2.0L", "Automática", 10000.8m, 35000.75m, 4, 5, "O Kia Sportage 2021 é um SUV elegante e espaçoso, com um interior confortável, tecnologia intuitiva e um desempenho confiável."),
                new Carro("Fiat", "Uno", "2020", "Branco", "Hatchback", "1.0L", "Manual", 8000.5m, 20000.00m, 2, 4, "O Fiat Uno 2020 é um hatchback compacto e econômico, ideal para a cidade, com um design moderno e recursos práticos."),
                new Carro("Renault", "Sandero", "2019", "Azul", "Hatchback", "1.6L", "Manual", 9000.3m, 25000.25m, 4, 5, "O Renault Sandero 2019 é um hatchback espaçoso e confortável, com um design atraente e uma excelente relação custo-benefício."),
                new Carro("Nissan", "Versa", "2022", "Cinza", "Sedan", "1.6L", "Manual", 7500.7m, 28000.50m, 4, 5, "O Nissan Versa 2022 é um sedan versátil e eficiente, com um interior espaçoso, tecnologia avançada e um bom desempenho."),
                new Carro("Volvo", "XC60", "2021", "Preto", "SUV", "2.0L", "Automática", 11000.9m, 45000.75m, 4, 5, "O Volvo XC60 2021 é um SUV de luxo com um design elegante, conforto excepcional e tecnologia inovadora para uma experiência de condução premium."),
                new Carro("Mazda", "CX-5", "2020", "Vermelho", "SUV", "2.5L", "Automática", 8500.6m, 38000.00m, 4, 5, "O Mazda CX-5 2020 é um SUV sofisticado e esportivo, com um interior requintado, desempenho emocionante e recursos avançados de segurança."),
                new Carro("Subaru", "Impreza", "2019", "Prata", "Hatchback", "2.0L", "Manual", 7000.4m, 32000.25m, 4, 5, "O Subaru Impreza 2019 é um hatchback ágil e confiável, com tração nas quatro rodas, tecnologia intuitiva e um design distinto."),
                new Carro("Lexus", "RX", "2022", "Branco", "SUV", "3.5L", "Automática", 12000.8m, 50000.75m, 4, 5, "O Lexus RX 2022 é um SUV de luxo com um interior refinado, desempenho suave e uma ampla gama de recursos de conforto e segurança."),
                new Carro("Land Rover", "Range Rover Evoque", "2021", "Preto", "SUV", "2.0L", "Automática", 10000.5m, 45000.00m, 4, 5, "O Land Rover Range Rover Evoque 2021 é um SUV sofisticado e robusto, com um design icônico, capacidades off-road impressionantes e um interior luxuoso."),
                new Carro("Jeep", "Compass", "2020", "Vermelho", "SUV", "2.0L", "Automática", 9000.3m, 40000.25m, 4, 5, "O Jeep Compass 2020 é um SUV versátil e resistente, com um design atraente, conforto refinado e capacidade off-road."),
                new Carro("Porsche", "911", "2019", "Amarelo", "Cupê", "3.0L", "Automática", 6000.2m, 70000.50m, 2, 4, "O Porsche 911 2019 é um cupê esportivo lendário, com um desempenho excepcional, tecnologia avançada e um design atemporal."),
                new Carro("Jaguar", "F-Pace", "2022", "Azul", "SUV", "2.0L", "Automática", 8000.8m, 55000.75m, 4, 5, "O Jaguar F-Pace 2022 é um SUV de luxo com um design elegante, dinâmica de condução empolgante e um interior requintado com tecnologia de ponta."),
                new Carro("Tesla", "Model S", "2021", "Branco", "Sedan", "Elétrico", "Automática", 5000.7m, 90000.50m, 4, 5, "O Tesla Model S 2021 é um sedan elétrico de alto desempenho, com aceleração impressionante, autonomia excepcional e recursos de segurança avançados."),
                new Carro("Alfa Romeo", "Giulia", "2020", "Vermelho", "Sedan", "2.0L", "Automática", 7000.5m, 60000.00m, 4, 5, "O Alfa Romeo Giulia 2020 é um sedan esportivo e elegante, com um design italiano icônico, um motor potente e uma experiência de condução emocionante."),
                new Carro("Maserati", "Ghibli", "2019", "Preto", "Sedan", "3.0L", "Automática", 9000.3m, 75000.25m, 4, 5, "O Maserati Ghibli 2019 é um sedan de luxo com um design sofisticado, desempenho poderoso e um interior luxuoso com detalhes artesanais."),
                new Carro("Mini", "Cooper", "2022", "Branco", "Hatchback", "1.5L", "Automática", 6000.2m, 35000.50m, 2, 4, "O Mini Cooper 2022 é um hatchback compacto e estiloso, com um caráter divertido, desempenho ágil e um interior cheio de personalidade."),
                new Carro("Acura", "TLX", "2021", "Prata", "Sedan", "2.0L", "Automática", 8000.8m, 40000.75m, 4, 5, "O Acura TLX 2021 é um sedan de luxo com um design elegante, desempenho esportivo e tecnologia avançada para uma experiência de condução refinada."),
                new Carro("Infiniti", "Q50", "2020", "Azul", "Sedan", "3.0L", "Automática", 10000.5m, 45000.00m, 4, 5, "O Infiniti Q50 2020 é um sedan sofisticado e confortável, com um motor potente, tecnologia inovadora e um design atraente."),
                new Carro("Lamborghini", "Huracán", "2019", "Amarelo", "Cupê", "5.2L", "Automática", 3000.3m, 500000.25m, 2, 2, "O Lamborghini Huracán 2019 é um cupê de alto desempenho, com um motor poderoso, aerodinâmica avançada e um design exótico."),
                new Carro("Bentley", "Continental GT", "2022", "Prata", "Cupê", "4.0L", "Automática", 15000.9m, 550000.75m, 2, 4, "O Bentley Continental GT 2022 é um cupê de luxo com um design elegante, interior refinado e um desempenho excepcional."),
                new Carro("Rolls-Royce", "Phantom", "2021", "Preto", "Sedan", "6.8L", "Automática", 2000.6m, 1000000.00m, 4, 5, "O Rolls-Royce Phantom 2021 é um sedan de luxo supremo, com um interior opulento, tecnologia de última geração e uma presença imponente."),
                new Carro("Ferrari", "488 GTB", "2020", "Vermelho", "Cupê", "3.9L", "Automática", 5000.4m, 800000.25m, 2, 2, "O Ferrari 488 GTB 2020 é um cupê esportivo de alto desempenho, com um motor turbo V8, aerodinâmica avançada e um design icônico."),
                new Carro("Porsche", "Panamera", "2019", "Branco", "Sedan", "3.0L", "Automática", 9000.7m, 60000.50m, 4, 5, "O Porsche Panamera 2019 é um sedan de luxo versátil, com um desempenho emocionante, tecnologia avançada e espaço para toda a família."),
                new Carro("Lexus", "ES", "2022", "Azul", "Sedan", "2.5L", "Automática", 8000.5m, 55000.00m, 4, 5, "O Lexus ES 2022 é um sedan de luxo com um design elegante, conforto excepcional e um conjunto abrangente de recursos de segurança e tecnologia."),
                new Carro("Audi", "Q5", "2021", "Prata", "SUV", "2.0L", "Automática", 12000.9m, 50000.75m, 4, 5, "O Audi Q5 2021 é um SUV premium com um design moderno, desempenho esportivo e uma cabine espaçosa e luxuosa."),
                new Carro("BMW", "X5", "2020", "Preto", "SUV", "3.0L", "Automática", 10000.6m, 60000.00m, 4, 5, "O BMW X5 2020 é um SUV de luxo com um equilíbrio perfeito entre desempenho, conforto e tecnologia, oferecendo uma experiência de condução emocionante."),
                new Carro("Mercedes-Benz", "E-Class", "2019", "Cinza", "Sedan", "2.0L", "Automática", 9000.4m, 55000.25m, 4, 5, "O Mercedes-Benz E-Class 2019 é um sedan elegante e sofisticado, com um interior luxuoso, tecnologia avançada e um desempenho suave."),
                new Carro("Jaguar", "XE", "2022", "Branco", "Sedan", "2.0L", "Automática", 7000.2m, 45000.50m, 4, 5, "O Jaguar XE 2022 é um sedan de luxo com um design arrojado, dinâmica de condução esportiva e uma cabine refinada com tecnologia de ponta."),
                new Carro("Cadillac", "CT5", "2021", "Prata", "Sedan", "2.0L", "Automática", 8000.8m, 50000.75m, 4, 5, "O Cadillac CT5 2021 é um sedan sofisticado e elegante, com um interior espaçoso, tecnologia avançada e um desempenho poderoso."),
                new Carro("Chevrolet", "Camaro", "2020", "Vermelho", "Cupê", "6.2L", "Automática", 6000.7m, 60000.50m, 2, 4, "O Chevrolet Camaro 2020 é um cupê esportivo icônico, com um design agressivo, motor V8 potente e um desempenho emocionante."),
                new Carro("Dodge", "Challenger", "2019", "Preto", "Cupê", "5.7L", "Automática", 5000.5m, 55000.00m, 2, 4, "O Dodge Challenger 2019 é um cupê musculoso e poderoso, com um estilo retrô, desempenho de alta potência e um interior moderno."),
                new Carro("Ford", "Mustang", "2022", "Azul", "Cupê", "5.0L", "Automática", 7000.9m, 65000.75m, 2, 4, "O Ford Mustang 2022 é um cupê lendário, com um design icônico, motor V8 emocionante e uma experiência de condução emocionante."),
                new Carro("Nissan", "GT-R", "2021", "Prata", "Cupê", "3.8L", "Automática", 6000.6m, 80000.00m, 2, 2, "O Nissan GT-R 2021 é um cupê de alto desempenho, com um motor turbo V6, tecnologia avançada e um design aerodinâmico."),
                new Carro("Toyota", "Supra", "2020", "Vermelho", "Cupê", "3.0L", "Automática", 5000.4m, 70000.25m, 2, 2, "O Toyota Supra 2020 é um cupê esportivo emocionante, com um design elegante, desempenho ágil e uma experiência de condução envolvente."),
                new Carro("Mazda", "MX-5 Miata", "2019", "Branco", "Conversível", "2.0L", "Automática", 4000.2m, 45000.50m, 2, 2, "O Mazda MX-5 Miata 2019 é um conversível clássico, com um design esportivo, leveza e agilidade, e uma condução pura e divertida."),
                new Carro("Subaru", "WRX STI", "2022", "Azul", "Sedan", "2.5L", "Manual", 3000.7m, 40000.75m, 4, 5, "O Subaru WRX STI 2022 é um sedan esportivo com tração nas quatro rodas, um motor turbocharged, estilo agressivo e uma condução empolgante."),
                new Carro("Volkswagen", "Golf GTI", "2021", "Cinza", "Hatchback", "2.0L", "Automática", 5000.5m, 35000.00m, 2, 4, "O Volkswagen Golf GTI 2021 é um hatchback esportivo e versátil, com um desempenho emocionante, manuseio preciso e um interior confortável."),
                new Carro("Hyundai", "Veloster", "2020", "Amarelo", "Hatchback", "1.6L", "Automática", 6000.9m, 30000.25m, 3, 4, "O Hyundai Veloster 2020 é um hatchback único e esportivo, com um design assimétrico, recursos avançados e uma condução divertida."),
                new Carro("Kia", "Stinger", "2019", "Vermelho", "Sedan", "3.3L", "Automática", 7000.6m, 40000.50m, 4, 5, "O Kia Stinger 2019 é um sedan de alto desempenho, com um design arrojado, um motor turbo V6 potente e uma cabine luxuosa."),
                new Carro("Volvo", "XC90", "2022", "Preto", "SUV", "2.0L", "Automática", 9000.4m, 55000.25m, 4, 7, "O Volvo XC90 2022 é um SUV de luxo com um design escandinavo elegante, tecnologia avançada de segurança e um interior espaçoso e confortável."),
                new Carro("Mitsubishi", "Outlander", "2021", "Branco", "SUV", "2.5L", "Automática", 8000.2m, 45000.50m, 4, 7, "O Mitsubishi Outlander 2021 é um SUV versátil e confiável, com um design moderno, espaço para toda a família e tecnologia conveniente.")
            };

            return lstCarro;
        }
    }
}
