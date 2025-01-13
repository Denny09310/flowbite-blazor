/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './{Components,Icons}/**/*.{razor,cs}',
        "./node_modules/flowbite/**/*.js"
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ],
}
