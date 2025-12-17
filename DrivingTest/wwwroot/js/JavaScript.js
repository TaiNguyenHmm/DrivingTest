document.addEventListener('DOMContentLoaded', function () {
    const tabButtons = document.querySelectorAll('.tab-btn');
    const tabContents = document.querySelectorAll('.tab-content');
    const pageTitle = document.getElementById('page-title');
    const searchInputs = document.querySelectorAll("input[data-target]");

    function switchTab(targetTabId) {
        tabButtons.forEach(btn => btn.classList.remove('active-tab'));
        tabContents.forEach(content => {
            content.classList.add('hidden');
            content.classList.remove('active');
        });

        const selectedButton = document.querySelector(`.tab-btn[data-tab="${targetTabId}"]`);
        const selectedContent = document.getElementById(targetTabId);

        if (selectedButton && selectedContent) {
            selectedButton.classList.add('active-tab');
            selectedContent.classList.remove('hidden');
            selectedContent.classList.add('active');

            const span = selectedButton.querySelector('span');
            if (span) pageTitle.textContent = span.textContent;
        }
    }

    const urlParams = new URLSearchParams(window.location.search);
    const tab = urlParams.get("tab");
    switchTab(tab ?? "dashboard");

    tabButtons.forEach(button => {
        button.addEventListener("click", function () {
            switchTab(this.dataset.tab);
        });
    });

    searchInputs.forEach(input => {
        input.addEventListener("input", function () {
            const filter = input.value.toLowerCase();
            const tableBody = document.getElementById(input.dataset.target);
            if (!tableBody) return;

            [...tableBody.rows].forEach(row => {
                row.style.display = row.textContent.toLowerCase().includes(filter) ? "" : "none";
            });
        });
    });

    document.querySelectorAll(".status-badge").forEach(el => {
        el.addEventListener("click", async () => {
            if (el.innerText.trim() !== "Chờ Xử Lý") return;

            const id = el.dataset.id;
            const response = await fetch(`/Dashboard/Resolve?id=${id}`, { method: "POST" });

            if (response.ok) {
                el.innerText = "Đã Xử Lý";
                el.classList.replace("bg-yellow-100", "bg-green-100");
                el.classList.replace("text-yellow-800", "text-green-800");
            }
        });
    });
});
