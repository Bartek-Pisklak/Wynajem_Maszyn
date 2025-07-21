# GroundForce Rentals – Aplikacja do wynajmu maszyn ciężkich

**GroundForce Rentals** to nowoczesna aplikacja webowa stworzona w technologii .NET 8 i Blazor, umożliwiająca wynajem maszyn budowlanych i leśnych, takich jak koparki, walce, harwestery czy rozdrabniacze. Projekt został zrealizowany zgodnie z zasadami **Clean Architecture**, z wykorzystaniem wzorców **CQRS** i **DDD**.

## 🎯 Cel projektu

Celem aplikacji jest:
- Umożliwienie klientom przeglądania i rezerwacji maszyn online
- Ułatwienie zarządzania wynajmem i sprzętem przez pracowników
- Zapewnienie skalowalnej i przejrzystej architektury systemu
## 🧩 Kluczowe funkcje

- 🔐 Rejestracja i logowanie użytkowników
- 📅 System rezerwacji z kalendarzem dostępności
- 🔍 Wyszukiwarka maszyn z filtrami (moc, cena, typ, lokalizacja)
- 🧑‍💼 Panel pracownika do zarządzania maszynami i rezerwacjami
- 🛠️ Obsługa statusów technicznych maszyn (np. w naprawie)
- 🧾 Historia wypożyczeń i zarządzanie kontem użytkownika

## 👥 Role użytkowników

- **Przeglądający** – anonimowy użytkownik przeglądający ofertę
- **Wypożyczający** – zarejestrowany klient dokonujący rezerwacji
- **Obsługujący** – pracownik zatwierdzający i zarządzający wynajmem

## 🛠️ Technologie

- **Backend:** .NET 8, ASP.NET Core, Entity Framework Core
- **Frontend:** Blazor Server + MudBlazor (UI)
- **Baza danych:** PostgreSQL
- **Konteneryzacja:** Docker + Docker Compose
- **CQRS & DDD:** MediatR, FluentValidation, ErrorOr
- **Testy:** xUnit, Moq, FluentAssertions, NetArchTest

## 🧪 Testowanie

- Testy jednostkowe dla CQRS (komendy i zapytania)
- Testy architektury zgodne z zasadami Clean Architecture
- Pokrycie kodu mierzone za pomocą Coverlet
