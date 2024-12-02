export async function getCss(dotnet, html) {
    const styleTags = document.querySelectorAll('style')
    let result = ''

    styleTags.forEach(style => {
        if(style.textContent.slice(0, 20).includes('tailwind')){
            result = style.textContent
        }
        })
    return result
}