(() => {
    const FLOWBITE_SCRIPT_SRC = '_content/Flowbite.Blazor/lib/flowbite/dist/flowbite.min.js';

    // Load the Flowbite script
    const loadFlowbiteScript = () => {
        const script = document.createElement('script');
        script.src = FLOWBITE_SCRIPT_SRC;
        script.async = true;
        script.onload = () => {
            if (typeof initFlowbite === 'function') {
                initFlowbite();
            }
        };
        document.body.appendChild(script);
    };

    // Debounce utility function
    const debounce = (func, delay) => {
        let timeoutId;
        return (...args) => {
            clearTimeout(timeoutId);
            timeoutId = setTimeout(() => func(...args), delay);
        };
    };

    // Initialize Flowbite with debouncing
    const initializeFlowbite = debounce(() => {
        if (typeof initFlowbite === 'function') {
            initFlowbite();
        }
    }, 300);

    // Observe DOM changes to reinitialize Flowbite
    const observeDOMChanges = () => {
        const observer = new MutationObserver(initializeFlowbite);
        observer.observe(document.body, {
            childList: true,
            subtree: true,
        });
    };

    // Execute script loading and observer setup
    loadFlowbiteScript();
    observeDOMChanges();
})();
