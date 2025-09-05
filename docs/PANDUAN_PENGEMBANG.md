# Panduan Pengembangan OxVidco

Dokumen ini berisi panduan untuk pengembang yang ingin berkontribusi pada pengembangan OxVidco.

## 🏗️ Struktur Proyek

```
OxVidco/
├── Commands/          # Implementasi ICommand
├── Converters/        # Konverter untuk data binding
├── Models/            # Model data
├── Resources/         # Resource aplikasi (gambar, ikon, dll.)
├── Services/          # Layanan aplikasi
├── ViewModels/        # ViewModel untuk MVVM
├── Views/             # Tampilan XAML
├── ffmpeg/            # Binari FFmpeg
└── docs/              # Dokumentasi
```

## 🛠️ Teknologi Utama

- **.NET 9.0**: Platform pengembangan utama
- **WPF (Windows Presentation Foundation)**: Untuk antarmuka pengguna
- **MVVM (Model-View-ViewModel)**: Pola arsitektur
- **FFmpeg**: Untuk pemrosesan video
- **Newtonsoft.Json**: Untuk serialisasi/deserialisasi JSON
- **HtmlAgilityPack**: Untuk parsing HTML (digunakan untuk pembaruan)

## 🔧 Panduan Kontribusi

### Persyaratan

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- IDE (Visual Studio 2022 atau VS Code dengan ekstensi C#)
- Git

### Aturan Pengkodean

1. **Penamaan**
   - Gunakan Bahasa Inggris untuk nama variabel, kelas, dan method
   - Gunakan PascalCase untuk nama kelas dan method
   - Gunakan camelCase untuk variabel lokal dan parameter
   - Gunakan UPPER_CASE untuk konstanta

2. **Dokumentasi Kode**
   - Dokumentasikan semua kelas dan method publik
   - Gunakan komentar XML untuk dokumentasi API
   - Gunakan komentar `//` untuk penjelasan kode yang kompleks

3. **Struktur Kode**
   - Ikuti pola MVVM dengan ketat
   - Pisahkan logika bisnis dari UI
   - Gunakan dependency injection untuk ketergantungan

## 🧪 Pengujian

### Menjalankan Pengujian

```bash
dotnet test
```

### Panduan Pengujian

1. Tulis pengujian unit untuk semua logika bisnis
2. Gunakan framework xUnit atau NUnit
3. Ikuti konvensi penamaan `NamaKelas_MethodYangDiuji_HasilYangDiharapkan`

## 🔄 Siklus Pengembangan

1. Buat branch baru dari `main`
2. Tulis kode dan pengujian
3. Pastikan semua pengujian berhasil
4. Buat pull request ke branch `develop`
5. Lakukan code review
6. Merge ke `main` setelah disetujui

## 📦 Manajemen Paket

### Menambahkan Paket NuGet

```bash
dotnet add package Nama.Paket
```

### Memperbarui Paket

```bash
dotnet restore
dotnet list package --outdated
```

## 🔍 Debugging

### Masalah Umum

1. **FFmpeg tidak ditemukan**
   - Pastikan folder `ffmpeg` ada di direktori aplikasi
   - Pastikan file FFmpeg executable ada di dalamnya

2. **Error Binding**
   - Periksa Output window di Visual Studio untuk pesan binding error
   - Pastikan `DataContext` sudah di-set dengan benar

3. **Memory Leak**
   - Pastikan untuk melepas event handler yang sudah tidak digunakan
   - Gunakan WeakEventManager untuk event yang rentan memory leak

## 📝 Catatan Rilis

### v1.0.1
- Perbaikan bug minor
- Peningkatan stabilitas

### v1.0.0
- Rilis awal OxVidco
- Fitur konversi video dasar
- Antarmuka pengguna sederhana

---

📅 Terakhir diperbarui: September 2025
