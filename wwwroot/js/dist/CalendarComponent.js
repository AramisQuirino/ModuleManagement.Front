// CalendarComponent.js
// Usamos las variables globales definidas por los scripts UMD
"use strict";

var React = window.React;
var ReactDOM = window.ReactDOM;
var reactToWebComponent = window.reactToWebComponent || window.ReactToWebComponent;

console.log("React:", React);
console.log("ReactDOM:", ReactDOM);
console.log("reactToWebComponent:", reactToWebComponent);

var CalendarComponent = function CalendarComponent(_ref) {
    var professionals = _ref.professionals;
    var appointments = _ref.appointments;
    var dayStart = _ref.dayStart;
    var slotSizePx = _ref.slotSizePx;

    // Generamos los 40 intervalos (cada 15 min, de 8:00 a 18:00)
    var totalSlots = 40;
    var timeSlots = [];
    for (var i = 0; i < totalSlots; i++) {
        var slotTime = new Date(dayStart.getTime() + i * 15 * 60000);
        timeSlots.push(slotTime);
    }

    // Función para calcular la posición (top) de una cita según su hora de inicio
    var getOffsetPx = function getOffsetPx(appointmentTime) {
        var diffMinutes = (new Date(appointmentTime).getTime() - dayStart.getTime()) / 60000;
        var intervals = diffMinutes / 15;
        return intervals * slotSizePx;
    };

    // Manejador para clicks en la columna del profesional
    var handleColumnClick = function handleColumnClick(e, professional) {
        // Obtenemos el rectángulo del contenedor clicado
        var rect = e.currentTarget.getBoundingClientRect();
        // Calculamos la coordenada Y relativa al contenedor
        var clickY = e.clientY - rect.top;
        // Determinamos el índice del intervalo (cada intervalo equivale a slotSizePx)
        var slotIndex = Math.floor(clickY / slotSizePx);
        // Calculamos la hora correspondiente
        var clickedTime = new Date(dayStart.getTime() + slotIndex * 15 * 60000);
        console.log("Click en " + professional.name + " en la posición Y " + clickY + "px, correspondiente a " + clickedTime.toLocaleTimeString());
        // Aquí podrías abrir un modal o crear una nueva cita
    };

    return React.createElement(
        "div",
        { className: "overflow-auto border border-gray-200 rounded-lg shadow-lg bg-white relative", style: { width: '100%', height: '800px' } },
        React.createElement(
            "div",
            { className: "flex bg-gray-50 border-b border-gray-200 sticky top-0 z-10" },
            React.createElement(
                "div",
                { className: "w-16 text-center font-semibold border-r border-gray-200 p-2" },
                "Hora"
            ),
            professionals.map(function (prof) {
                return React.createElement(
                    "div",
                    { key: prof.id, className: "flex-1 text-center font-semibold border-r border-gray-200 p-2" },
                    prof.name
                );
            })
        ),
        React.createElement(
            "div",
            { className: "flex relative", style: { height: '1200px' } },
            React.createElement(
                "div",
                { className: "w-16 border-r border-gray-200 bg-white sticky left-0 z-10" },
                timeSlots.map(function (slot, i) {
                    var rowBg = i % 2 === 0 ? "bg-white" : "bg-gray-50";
                    return React.createElement(
                        "div",
                        {
                            key: i,
                            className: "h-[30px] text-xs text-gray-600 border-b border-gray-100 flex items-center justify-center " + rowBg
                        },
                        slot.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                    );
                })
            ),
            React.createElement(
                "div",
                { className: "flex-1 flex overflow-hidden" },
                professionals.map(function (prof) {
                    return React.createElement(
                        "div",
                        {
                            key: prof.id,
                            className: "relative border-r border-gray-200 flex-1 cursor-pointer",
                            style: { height: '1200px' },
                            onClick: function (e) {
                                return handleColumnClick(e, prof);
                            }
                        },
                        timeSlots.map(function (slot, i) {
                            var rowBg = i % 2 === 0 ? "bg-white" : "bg-gray-50";
                            return React.createElement("div", {
                                key: i,
                                className: "absolute left-0 right-0 border-b border-gray-100 " + rowBg,
                                style: { top: i * slotSizePx + "px", height: slotSizePx + "px" }
                            });
                        }),
                        (function () {
                            var now = new Date();
                            if (now >= dayStart && now <= new Date(dayStart.getTime() + totalSlots * 15 * 60000)) {
                                var nowOffsetPx = getOffsetPx(now);
                                return React.createElement("div", {
                                    className: "absolute left-0 right-0 bg-red-500 h-[2px]",
                                    style: { top: nowOffsetPx + "px" }
                                });
                            }
                            return null;
                        })(),
                        appointments.filter(function (appt) {
                            return appt.professionalId === prof.id;
                        }).map(function (appt) {
                            var topPx = getOffsetPx(appt.startTime);
                            var endTime = appt.endTime ? new Date(appt.endTime) : new Date(new Date(appt.startTime).getTime() + 30 * 60000);
                            var heightPx = getOffsetPx(endTime) - topPx || slotSizePx;
                            return React.createElement(
                                "div",
                                {
                                    key: appt.id,
                                    className: "absolute bg-white shadow-md rounded px-2 py-1 cursor-pointer border-l-4 hover:shadow-lg transition-all duration-200",
                                    style: {
                                        top: topPx + "px",
                                        height: heightPx + "px",
                                        left: '5px',
                                        right: '5px',
                                        borderColor: prof.color
                                    },
                                    onClick: function (e) {
                                        e.stopPropagation();
                                        console.log("Ver detalles de cita", appt);
                                    }
                                },
                                React.createElement(
                                    "div",
                                    { className: "font-semibold text-sm text-gray-800" },
                                    appt.clientName
                                ),
                                React.createElement(
                                    "div",
                                    { className: "text-xs text-gray-600" },
                                    appt.note
                                ),
                                React.createElement(
                                    "div",
                                    { className: "mt-1 text-xs text-gray-500" },
                                    new Date(appt.startTime).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }),
                                    " -",
                                    " ",
                                    new Date(appt.endTime).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                                )
                            );
                        })
                    );
                })
            )
        )
    );
};

//
// Funciones para registrar y renderizar el componente desde el exterior
//
window.initializeCalendarComponent = function () {
    var WebCalendar = reactToWebComponent(CalendarComponent, React, ReactDOM);
    // Registramos el web component con la etiqueta 'reactcalendar'
    customElements.define('reactcalendar', WebCalendar);
    console.log("Web Component 'reactcalendar' registrado con éxito.");
};

window.renderReactCalendar = function (elementId, professionals, appointments) {
    var dayStart = new Date();
    dayStart.setHours(8, 0, 0, 0);
    var slotSizePx = 30;

    var container = document.getElementById(elementId);
    if (container) {
        ReactDOM.render(React.createElement(CalendarComponent, {
            professionals: professionals,
            appointments: appointments,
            dayStart: dayStart,
            slotSizePx: slotSizePx
        }), container);
    }
};
/* Encabezado sticky */ /* Cuerpo del calendario */ /* Columna de horas (sticky) */ /* Columnas para cada profesional */ /* Líneas de fondo (grid) */ /* (Opcional) Línea roja indicando la hora actual */ /* Citas de este profesional */