# HouseProject
W 2022 roku rozpoczynam budowę domu :) Projekt ten ma być odzwierciedleniem potrzeby monitorowania / nadzorowania etapu budowy (dokumenty, materiały, etapy, koszty).
W projekcie wykorzystuję wzorzec CQRS, baza danych oparta jest na MSSQL. W celach testowo-rozwojowych dodałem drugą wersję bazy danych (nierelacyjna) - Azure CosmosDb. 
Mechanizm uwierzytelniania i autoryzacji oparty jest na standardzie JWT. Są przypisane dwie role: user i userRO (tylko do odczytu).
Przy dodawaniu załaczników są one zapisywane na dysku oraz w bazie sql. Nie przewiduję dużej liczby załączników, zapisane w bazie sql służą jako backup.

Przewiduję dużą liczbę dokumentów, dlatego dla nich wprowadziłem stronicowanie, sortowanie oraz filtrowanie. Testowałem też protokół komunikacyjny OData, dla moich potrzeb jest
on mało przydatny i potraktowałem go jako ciekawostkę.

W przyszłości planuję zrobić frontend w react'cie.
