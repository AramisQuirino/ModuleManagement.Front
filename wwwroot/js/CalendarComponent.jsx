// CalendarComponent.js
// Usamos las variables globales definidas por los scripts UMD
const React = window.React;
const ReactDOM = window.ReactDOM;
const reactToWebComponent = window.reactToWebComponent || window.ReactToWebComponent;

console.log("React:", React);
console.log("ReactDOM:", ReactDOM);
console.log("reactToWebComponent:", reactToWebComponent);

const CalendarComponent = ({ professionals, appointments, dayStart, slotSizePx }) => {
    // Generamos los 40 intervalos (cada 15 min, de 8:00 a 18:00)
    const totalSlots = 40;
    const timeSlots = [];
    for (let i = 0; i < totalSlots; i++) {
        const slotTime = new Date(dayStart.getTime() + i * 15 * 60000);
        timeSlots.push(slotTime);
    }

    // Función para calcular la posición (top) de una cita según su hora de inicio
    const getOffsetPx = (appointmentTime) => {
        const diffMinutes = (new Date(appointmentTime).getTime() - dayStart.getTime()) / 60000;
        const intervals = diffMinutes / 15;
        return intervals * slotSizePx;
    };

    // Manejador para clicks en la columna del profesional
    const handleColumnClick = (e, professional) => {
        // Obtenemos el rectángulo del contenedor clicado
        const rect = e.currentTarget.getBoundingClientRect();
        // Calculamos la coordenada Y relativa al contenedor
        const clickY = e.clientY - rect.top;
        // Determinamos el índice del intervalo (cada intervalo equivale a slotSizePx)
        const slotIndex = Math.floor(clickY / slotSizePx);
        // Calculamos la hora correspondiente
        const clickedTime = new Date(dayStart.getTime() + slotIndex * 15 * 60000);
        console.log(`Click en ${professional.name} en la posición Y ${clickY}px, correspondiente a ${clickedTime.toLocaleTimeString()}`);
        // Aquí podrías abrir un modal o crear una nueva cita
    };

    return (
        <div className="overflow-auto border border-gray-200 rounded-lg shadow-lg bg-white relative" style={{ width: '100%', height: '800px' }}>
            {/* Encabezado sticky */}
            <div className="flex bg-gray-50 border-b border-gray-200 sticky top-0 z-10">
                <div className="w-16 text-center font-semibold border-r border-gray-200 p-2">Hora</div>
                {professionals.map((prof) => (
                    <div key={prof.id} className="flex-1 text-center font-semibold border-r border-gray-200 p-2">
                        {prof.name}
                    </div>
                ))}
            </div>

            {/* Cuerpo del calendario */}
            <div className="flex relative" style={{ height: '1200px' }}>
                {/* Columna de horas (sticky) */}
                <div className="w-16 border-r border-gray-200 bg-white sticky left-0 z-10">
                    {timeSlots.map((slot, i) => {
                        const rowBg = i % 2 === 0 ? "bg-white" : "bg-gray-50";
                        return (
                            <div
                                key={i}
                                className={`h-[30px] text-xs text-gray-600 border-b border-gray-100 flex items-center justify-center ${rowBg}`}
                            >
                                {slot.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                            </div>
                        );
                    })}
                </div>

                {/* Columnas para cada profesional */}
                <div className="flex-1 flex overflow-hidden">
                    {professionals.map((prof) => (
                        <div
                            key={prof.id}
                            className="relative border-r border-gray-200 flex-1 cursor-pointer"
                            style={{ height: '1200px' }}
                            onClick={(e) => handleColumnClick(e, prof)}
                        >
                            {/* Líneas de fondo (grid) */}
                            {timeSlots.map((slot, i) => {
                                const rowBg = i % 2 === 0 ? "bg-white" : "bg-gray-50";
                                return (
                                    <div
                                        key={i}
                                        className={`absolute left-0 right-0 border-b border-gray-100 ${rowBg}`}
                                        style={{ top: `${i * slotSizePx}px`, height: `${slotSizePx}px` }}
                                    ></div>
                                );
                            })}

                            {/* (Opcional) Línea roja indicando la hora actual */}
                            {(() => {
                                const now = new Date();
                                if (now >= dayStart && now <= new Date(dayStart.getTime() + totalSlots * 15 * 60000)) {
                                    const nowOffsetPx = getOffsetPx(now);
                                    return (
                                        <div
                                            className="absolute left-0 right-0 bg-red-500 h-[2px]"
                                            style={{ top: `${nowOffsetPx}px` }}
                                        ></div>
                                    );
                                }
                                return null;
                            })()}

                            {/* Citas de este profesional */}
                            {appointments
                                .filter((appt) => appt.professionalId === prof.id)
                                .map((appt) => {
                                    const topPx = getOffsetPx(appt.startTime);
                                    const endTime = appt.endTime ? new Date(appt.endTime) : new Date(new Date(appt.startTime).getTime() + 30 * 60000);
                                    const heightPx = getOffsetPx(endTime) - topPx || slotSizePx;
                                    return (
                                        <div
                                            key={appt.id}
                                            className="absolute bg-white shadow-md rounded px-2 py-1 cursor-pointer border-l-4 hover:shadow-lg transition-all duration-200"
                                            style={{
                                                top: `${topPx}px`,
                                                height: `${heightPx}px`,
                                                left: '5px',
                                                right: '5px',
                                                borderColor: prof.color,
                                            }}
                                            onClick={(e) => {
                                                e.stopPropagation();
                                                console.log("Ver detalles de cita", appt);
                                            }}
                                        >
                                            <div className="font-semibold text-sm text-gray-800">{appt.clientName}</div>
                                            <div className="text-xs text-gray-600">{appt.note}</div>
                                            <div className="mt-1 text-xs text-gray-500">
                                                {new Date(appt.startTime).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })} -{" "}
                                                {new Date(appt.endTime).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                                            </div>
                                        </div>
                                    );
                                })}
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

//
// Funciones para registrar y renderizar el componente desde el exterior
//
window.initializeCalendarComponent = () => {
    const WebCalendar = reactToWebComponent(CalendarComponent, React, ReactDOM);
    // Registramos el web component con la etiqueta 'reactcalendar'
    customElements.define('reactcalendar', WebCalendar);
    console.log("Web Component 'reactcalendar' registrado con éxito.");
};

window.renderReactCalendar = (elementId, professionals, appointments) => {
    const dayStart = new Date();
    dayStart.setHours(8, 0, 0, 0);
    const slotSizePx = 30;

    const container = document.getElementById(elementId);
    if (container) {
        ReactDOM.render(
            React.createElement(CalendarComponent, {
                professionals,
                appointments,
                dayStart,
                slotSizePx
            }),
            container
        );
    }
};
