function pushState(state) {
    var url = state.url;
    if (history.pushState == undefined) {
        History.pushState(state, "", url);
    } else {
        history.pushState(state, "", url);
    }
}

function setPopstate(operate) {
    if (history.pushState == undefined) {
        History.Adapter.bind(window, 'statechange', function() {
            var state = History.getState();
            operate(state);
        });
    } else {
        window.onpopstate = function() {
            var state = window.history.state;
            operate(state);
        }
    }
}

function replaceState(state) {
    var url = state.url;
    if (history.pushState == undefined) {
        History.replaceState(state, "", url);
    } else {
        history.replaceState(state, "", url);
    }
}