function openPopup() {
    var noticeCookie = getCookie("popup");
    if (noticeCookie != "no") {
        window.open('/popup.html', 'pop1', 'width=403,height=435,top=50,left=150');
    } else {
        alert('당분간은 팝업창이 뜨지 않습니다.')
    }
}
function getCookie(name) {
    var Found = false
    var start, end
    var i = 0

    while (i <= document.cookie.length) {
        start = i
        end = start + name.length
        if (document.cookie.substring(start, end) == name) {
            Found = true
            break
        }
        i++
    }

    if (Found == true) {
        start = end + 1
        end = document.cookie.indexOf(";", start)
        if (end < start)
            end = document.cookie.length
        return document.cookie.substring(start, end)
    }
    return ""
}