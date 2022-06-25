/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Views/**/*.{html,cshtml}"],
    theme: {
        container: {
            center: true,
            padding: {
                DEFAULT: "1rem",
                sm: "2rem",
            },
        },
        extend: {
            transitionDuration: {
                DEFAULT: "350ms",
            },
            colors: {
                primary: "#3445b4",
                secondary: "#44bef1",
            },
        },
    },
    plugins: [require("@tailwindcss/forms"), require("@tailwindcss/typography")],
};
