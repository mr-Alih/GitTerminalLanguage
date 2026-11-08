# GitTerminalLanguage (GTL)

**A personal terminal framework built around Git, custom commands, and AI integration.**

GTL is the next step from my original project, **VBALM**. What started as a Python script is now growing into a standalone executable framework built with C#.

The goal is simple: build my own terminal environment, create a custom command system, and bring different tools together in one place.

---

## What is GTL?

GTL stands for **GitTerminalLanguage**.

It is a personal development project focused on building a custom terminal experience. Instead of relying only on existing terminal commands, GTL aims to provide its own command structure and tools.

The project is being built step by step, with a focus on learning, control, and flexibility.

## Current Features

- **Custom command system** – A command structure designed specifically for GTL.
- **C# framework** – Built with C# and the .NET platform.
- **AI integration** – Connects to locally running AI models through Ollama.
- **Local execution** – Designed to run directly on your own machine.
- **Growing architecture** – Built to support more features as development continues.

*Features are actively being developed and may change over time.*

## Tech Stack

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| .NET 10 | Application framework |
| Ollama | Local AI integration |
| Git | Version control |
| VS Code | Development environment |

## AI Transparency

AI has played a very limited role in the development of GTL.

**Less than 5% of the development work involves AI assistance**, mainly for:
- Debugging errors.
- Understanding unfamiliar concepts.
- Getting basic technical guidance.

The project structure, implementation, decisions, and development process are my own work.

AI is used as a learning and debugging tool, not as a replacement for development.

## Project Goals

GTL is still under development. The long-term goals include:

- Expanding the custom command system.
- Building a more complete terminal interface.
- Improving local AI integration.
- Creating a flexible framework for future tools.
- Making GTL a fully usable standalone application.

## Project Status

<escape>🚧</escape> **In Development**

GTL is an ongoing personal project. Features are being added, tested, and improved as development continues.

## Origin

GTL started as **VBALM**, a Python-based project.

The decision to move to C# was made to create a more structured application with its own executable framework and room to grow.

This repository documents that journey.

---

**Built independently. Developed step by step. Powered by curiosity.**

*GitTerminalLanguage — GTL*

# Expand the code brackets(From IdeaBoard):
`GTL` (Command Parser).

`GTL Start` (Get a connection fixed).

`GTL Session` (status show).

`GTL Server` (status show).

`GTL connection`.

`GTL Connect --{CONNECTIONLINE} `(Connect to a connectionline).

`GTL Session --{SESSIONVERSION}` (Go to past session File).


`GTL Publish #--{Status check (Unneeded)} `(Publishes local files to sender conectionline to server)

`GTL Update `(Gets Serverfiles from current session to local)

`GTL Status`

`GTL Help`


`GTL Ai`  (Command Parser)

`GTL Ai ASK` (Ask Ai directly)

`GTL Ai bot` (Create new bot)

`GTL Ai {BOTNAME} [ACTION]` (Add action to botlist)

`GTL Ai {BOTNAME} Run` (Run a legacy bot an action directly (No time delay))


`GTL config set username` {USERNAME}

`GTL config get username` 

`GTL config list`

`GTL list`

## Further connection:
`GTL Disconnect`
`GTL Disconnect --force`

## History
`GTL History`
`GTL History --sessions`
`GTL History --connections`

## Versioncontrol
`GTL Rollback`
`GTL Rollback --{SESSIONVERSION}`
(Remember that rollback is only allowed at a connection based not server, local or Local(Session))


# Botting
Create an bot via the bot Command
the bot is allowed indefinetly to run with its own pressist.
Bots will will independant. Loop.
Bot wil run as agents in a cli.

