const statusConfig = {
            "Gönderi Alındı":      { icon: "bi-box-seam",    color: "#8b5cf6", bg: "rgba(139,92,246,0.12)" },
            "Transfer Merkezinde": { icon: "bi-building",     color: "#3b82f6", bg: "rgba(59,130,246,0.12)" },
            "Yolda":               { icon: "bi-truck",        color: "#088395", bg: "rgba(8,131,149,0.12)"  },
            "Dağıtımda":           { icon: "bi-bicycle",      color: "#f59e0b", bg: "rgba(245,158,11,0.12)" },
            "Teslim Edildi":       { icon: "bi-check-circle", color: "#16a34a", bg: "rgba(22,163,74,0.12)"  }
        };

        function selectStatus(card) {
            document.querySelectorAll('.status-card').forEach(c => c.classList.remove('selected'));
            card.classList.add('selected');
            document.getElementById('trackingStatusInput').value = card.getAttribute('data-status');
            updatePreview();
        }

        function updatePreview() {
            const location    = document.getElementById('locationInput').value;
            const description = document.getElementById('descriptionInput').value;
            const dateVal     = document.getElementById('eventDateInput').value;
            const status      = document.getElementById('trackingStatusInput').value;

            const locEl = document.getElementById('previewLocation');
            locEl.textContent = location || 'Lokasyon giriniz...';
            locEl.style.color = location ? 'var(--dark)' : '#94a3b8';

            document.getElementById('previewDesc').textContent = description || 'A??klama giriniz...';

            if (dateVal) {
                const d = new Date(dateVal);
                document.getElementById('previewDate').textContent =
                    d.toLocaleDateString('tr-TR', { day:'2-digit', month:'2-digit', year:'numeric' }) + ' ' +
                    d.toLocaleTimeString('tr-TR', { hour:'2-digit', minute:'2-digit' });
            }

            if (status && statusConfig[status]) {
                const cfg = statusConfig[status];
                const badge = document.getElementById('previewBadge');
                badge.style.background = cfg.bg;
                badge.style.color = cfg.color;
                document.getElementById('previewStatusText').textContent = status;
                const dot = document.getElementById('previewDot');
                dot.style.background = cfg.color;
                dot.style.boxShadow  = `0 0 0 4px ${cfg.bg}`;
                document.getElementById('previewDotIcon').className = `bi ${cfg.icon}`;
            }
        }

        document.getElementById('descriptionInput').addEventListener('input', function () {
            document.getElementById('descCounter').textContent = this.value.length;
            updatePreview();
        });

        document.getElementById('locationInput').addEventListener('input', updatePreview);
        document.getElementById('eventDateInput').addEventListener('change', updatePreview);

        window.addEventListener('load', function () {
            const now   = new Date();
            const local = new Date(now.getTime() - now.getTimezoneOffset() * 60000);
            document.getElementById('eventDateInput').value = local.toISOString().slice(0, 16);
            updatePreview();
        });

        document.querySelector('form').addEventListener('submit', function (e) {
            if (!document.getElementById('trackingStatusInput').value) {
                e.preventDefault();
                alert('L?tfen bir kargo durumu se?iniz!');
            }
        });
