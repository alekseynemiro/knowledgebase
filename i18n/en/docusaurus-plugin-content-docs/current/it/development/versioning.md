---
description: Version numbering agreement.
tags:
  - Guide
  - Version
  - semver
---

# Versioning

:::warning
This document has been translated using machine translation without human review.
:::

In most cases, I adhere to the **[SemVer v2.0](https://semver.org)** standard. Version numbers have the following format:

```text
Major.Minor.Patch[-Suffix]
```

* `Major` — critical changes affecting backward compatibility.
* `Minor` — significant changes while maintaining backward compatibility (adding, removing, changing functionality).
* `Patch` — bug fixes, while maintaining backward compatibility.
* `-Suffix` — optional, can be used for pre-release versions. If there are multiple pre-release versions, an additional release number is specified with a dot. For example, `-alpha`, `-beta`, `-rc`, `-alpha.1`, `-beta.5`.

Examples:

* `1.0.0`
* `1.0.0-alpha.7`
* `1.2.21`
* `1.1.0-beta.1`

The major version numbering starts from one. In rare cases, for example in **Python**, it may start from zero.

In **.NET** projects, the **SemVer v2.0** standard is used as the package version (**Package Version**).
For assembly versions (**Assembly Version**), a four-part number is used, where the first three correspond to the scheme above, and the fourth number is the build number (automatic build number from **Jenkins**, **TeamCity**, etc., or simply a counter).

Using a counter for the build number is useful when the source code does not change, but the build result might change. For example, if the build occurs in different environments, on different systems. Or if an error occurred during the build and some necessary files were not included in the build (due to unavailability, locking, etc.), while the build itself completed successfully and the problem was not detected immediately. This is especially relevant for packages.

It is also convenient to specify the hash of the last commit (git hash) in the version number, if technically possible. This is useful in large application projects when different environments (Test, UAT, Prod) are used, there is QA, or the possibility of receiving feedback from users.

Examples of version numbers with metadata from the version control system (such as git):

* `1.0.0.272+9a847b1`
* `1.2.0.59+9a847b1489be6642b90ff53c0803d21bc8d2cae2`
* `3.4.7.1708+9a847b1489be6642b90ff53c0803d21bc8d2cae2;2025-09-23T11:01:11;master`
