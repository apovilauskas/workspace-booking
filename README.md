# Workspace Booking Platform

An ASP.NET Core MVC dashboard designed for managing workspace and meeting room reservations in real-time.

## Tech Stack & Architecture

ASP.NET Core MVC, Razor Views, built-in DI container, routing, model binding, in-memory lists, async/await basics (to simulate databases with multiple users), C# records.

## Features

* **Real-Time Availability:** Rooms dynamically disappear from the available list upon booking and reappear automatically once reservation hours expire.
* **Book And Cancel Bookings:** Active booking table utilizes a minimalist layout where the "Cancel" action fades into view only when hovering over a specific row.
* **Input Validation:** Implements server-side guard clauses preventing over-booking, restricting bookings to a maximum of 12 hours, enforcing a 32-character limit on names, and validating true room existence.
* **Compact UI Architecture:** Utilizes sticky-header scrollable containers restricting views to 5 items max, ensuring dashboard readability as room inventory grows.
