[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Smidgens/UnityQuickBuild/master/LICENSE.md)

# Unity Snippet Scripts

A collection of standalone utility scripts aimed to make it easy to quickly chain together functionality and alleviate the need to implement basic functionality such as timed waiting or scene loading.

Every script aims to be highly single responsible and independent in design. By this principle, they don't:
* ...implement any of Unity's script events such as "Update" or "Awake". Their functions need to called manually (linked in the inspector ideally, though still callable through code).
* ...reference each other. They can be selectively installed in a project without the need to consider missing dependencies. 
* ...depend on anything outside the core features of Unity. They should be compatible with most recent versions of Unity, if not some of its older versions for the more basic scripts.

## Examples

| On Unity Event |
| ------------- |
| Executes on the specified script event; can be combined with other scripts through the editor. |
| ![Unity Event](/Screenshots/01.png?raw=true "Unity Event") ![Unity Event](/Screenshots/02.png?raw=true "Unity Event") |
