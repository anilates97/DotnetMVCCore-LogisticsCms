function formatLocation(city, district, prefix) {
    const cityValue = city?.trim();
    const districtValue = district?.trim();

    if (!cityValue || !districtValue) {
        return `${prefix}: Şehir / İlçe`;
    }

    return `${prefix}: ${cityValue} / ${districtValue}`;
}

function updatePreview() {
    const trackingInput = document.getElementById("trackingInput");
    const senderInput = document.getElementById("senderInput");
    const receiverInput = document.getElementById("receiverInput");
    const originCityInput = document.getElementById("originCityInput");
    const originDistrictInput = document.getElementById("originDistrictInput");
    const destinationCityInput = document.getElementById("destinationCityInput");
    const destinationDistrictInput = document.getElementById("destinationDistrictInput");
    const addressInput = document.getElementById("addressInput");
    const dateInput = document.getElementById("dateInput");
    const statusInput = document.getElementById("statusInput");

    document.getElementById("previewTracking").textContent = trackingInput?.value || "TRK-XXXXXXXX";
    document.getElementById("previewSender").textContent = senderInput?.value || "-";
    document.getElementById("previewReceiver").textContent = receiverInput?.value || "-";
    document.getElementById("previewOriginFull").textContent = formatLocation(
        originCityInput?.value,
        originDistrictInput?.value,
        "Çıkış");
    document.getElementById("previewDestinationFull").textContent = formatLocation(
        destinationCityInput?.value,
        destinationDistrictInput?.value,
        "Varış");

    const address = addressInput?.value || "-";
    document.getElementById("previewAddress").textContent =
        address.length > 50 ? `${address.substring(0, 50)}...` : address;

    if (dateInput?.value) {
        const date = new Date(dateInput.value);
        const formatted = date.toLocaleDateString("tr-TR", {
            day: "2-digit",
            month: "2-digit",
            year: "numeric",
            hour: "2-digit",
            minute: "2-digit"
        });
        document.getElementById("previewDate").textContent = formatted;
    } else {
        document.getElementById("previewDate").textContent = "-";
    }

    document.getElementById("previewStatus").textContent = statusInput?.value || "Bekliyor";
}

window.addEventListener("load", () => {
    [
        "trackingInput",
        "senderInput",
        "receiverInput",
        "originCityInput",
        "originDistrictInput",
        "destinationCityInput",
        "destinationDistrictInput",
        "addressInput",
        "dateInput",
        "statusInput"
    ].forEach((id) => {
        const element = document.getElementById(id);
        if (element) {
            element.addEventListener("input", updatePreview);
            element.addEventListener("change", updatePreview);
        }
    });

    updatePreview();
});

document.getElementById("shipmentForm")?.addEventListener("submit", (event) => {
    const originCity = document.getElementById("originCityInput")?.value.trim() || "";
    const originDistrict = document.getElementById("originDistrictInput")?.value.trim() || "";
    const destinationCity = document.getElementById("destinationCityInput")?.value.trim() || "";
    const destinationDistrict = document.getElementById("destinationDistrictInput")?.value.trim() || "";

    if (!originCity || !originDistrict || !destinationCity || !destinationDistrict) {
        event.preventDefault();
        alert("Lütfen çıkış ve varış şehir/ilçe bilgilerini eksiksiz doldurun!");
        return false;
    }

    if (
        originCity.toLocaleLowerCase("tr-TR") === destinationCity.toLocaleLowerCase("tr-TR") &&
        originDistrict.toLocaleLowerCase("tr-TR") === destinationDistrict.toLocaleLowerCase("tr-TR")
    ) {
        event.preventDefault();
        alert("Çıkış ve varış lokasyonu aynı olamaz!");
        return false;
    }

    return true;
});
