function kargoHesapla() {
    // Değerleri al
    const servisFiyat = parseFloat(document.getElementById('kargo-servis').value) || 0;
    const agirlik = parseFloat(document.getElementById('kargo-agirlik').value) || 0;
    const adet = parseInt(document.getElementById('kargo-adet').value) || 1;
    const emtiaEl = document.getElementById('kargo-emtia');
    const emtiaCarpan = parseFloat(emtiaEl.value) || 1;

    // Ek hizmetler
    const ekspres = document.getElementById('cb-ekspres').checked ? 40 : 0;
    const sigorta = document.getElementById('cb-sigorta').checked ? 20 : 0;
    const paket = document.getElementById('cb-paket').checked ? 15 : 0;

    // Ağırlık bazlı fiyat: kg başına 5 TL
    const agirlikFiyat = agirlik * 5;

    // Toplam hesaplama
    const araToplam = (servisFiyat + agirlikFiyat) * adet * emtiaCarpan;
    const ekHizmetler = (ekspres + sigorta + paket);
    const toplam = araToplam + ekHizmetler;

    // Sonuç göster
    const sonucWrapper = document.getElementById('kargo-sonuc-wrapper');
    const toplamEl = document.getElementById('kargo-toplam-fiyat');
    const detayEl = document.getElementById('kargo-detay-listesi');

    if (toplam > 0) {
        toplamEl.textContent = '₺' + toplam.toFixed(2).replace('.', ',');
        sonucWrapper.style.display = 'block';

        // Detay satırları
        let detayHTML = '';
        if (servisFiyat > 0) detayHTML += '<span>🚚 Servis: <b>₺' + servisFiyat + '</b></span>';
        if (agirlikFiyat > 0) detayHTML += '<span>⚖️ Ağırlık (' + agirlik + ' kg): <b>₺' + agirlikFiyat.toFixed(2) + '</b></span>';
        if (adet > 1) detayHTML += '<span>📦 Adet: <b>x' + adet + '</b></span>';
        if (emtiaCarpan > 1) detayHTML += '<span>🏭 Emtia çarpanı: <b>x' + emtiaCarpan + '</b></span>';
        if (ekspres > 0) detayHTML += '<span>⚡ Ekspres: <b>+₺' + ekspres + '</b></span>';
        if (sigorta > 0) detayHTML += '<span>🛡️ Sigorta: <b>+₺' + sigorta + '</b></span>';
        if (paket > 0) detayHTML += '<span>📋 Paketleme: <b>+₺' + paket + '</b></span>';

        detayEl.innerHTML = detayHTML || '<span style="color:#94a3b8;">Lütfen servis ve ağırlık bilgisi giriniz.</span>';

        // Animasyon efekti
        const kart = document.getElementById('kargo-sonuc-kart');
        kart.style.transform = 'scale(1.01)';
        setTimeout(() => { kart.style.transform = 'scale(1)'; }, 150);
        kart.style.transition = 'transform 0.15s ease';
    } else {
        sonucWrapper.style.display = 'none';
    }
}

// Tüm select'lere de event listener ekle
document.addEventListener('DOMContentLoaded', function() {
    ['kargo-servis', 'kargo-alim', 'kargo-teslimat', 'kargo-emtia', 'kargo-adet'].forEach(function(id) {
        const el = document.getElementById(id);
        if (el) el.addEventListener('change', kargoHesapla);
    });
});
