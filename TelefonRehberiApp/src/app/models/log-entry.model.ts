export interface LogEntry {
    id: number;             
    logDate: Date;          // Log kaydının oluşturulma tarihi
    logLevel: string;       // Log seviyesini (Info, Warning, Error vb.) belirtir
    logger: string;         // Log'ı üreten bileşenin adı
    message: string;        // Log mesajı
    exception?: string;     // Bir hata durumu varsa hata detayları, olması sart degil
}
  